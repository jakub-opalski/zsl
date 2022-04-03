using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VehicleFactory.Abstract;
using VehicleFactory.Enums;
using VehicleFactory.Helpers;
using VehicleFactory.Models;

namespace VehicleFactory.Services
{
    public class VehicleAssemblyService
    {
        private ILogger _logger;
        private List<VehicleModel> _vehicleModels;
        private List<VehicleAssemblyData> _assemblyVehiclesList;
        private IDataStorage<VehicleAssemblyData> _dataStorage;
        private Random _random = new Random();
        private IExportLogsService _exportLogsService;

        public VehicleAssemblyService(ILogger logger, IDataStorage<VehicleAssemblyData> dataStorage,
            IExportLogsService exportLogsService)
        {
            _logger = logger;
            _dataStorage = dataStorage;
            _vehicleModels = new List<VehicleModel>();
            _assemblyVehiclesList = new List<VehicleAssemblyData>();
            _exportLogsService = exportLogsService;
        }

        public ServiceResult AddNewModel(string name)
        {
            if (_vehicleModels.Any(x =>x.Model.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return new ServiceResult(false, "This model is already added");
            }

            _vehicleModels.Add(new VehicleModel
            {
                Model = name
            });
            _logger.LogMessage($"New model added: { name }");
            return new ServiceResult();
        }

        public ServiceResult ScheduleProduction(string name, int numberOfModels)
        {
            var model = _vehicleModels.FirstOrDefault(x => x.Model.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (model == null)
            {
                return new ServiceResult(false, "This model doesn't exists");
            }
            
            _logger.LogMessage($"Scheduling production for: { name }, Number of models: { numberOfModels }");

            for (var i = 0; i< numberOfModels; i++)
            {
                ScheduleProductionSingleVehicle(model);
            }

            return new ServiceResult();
        }

        private void ScheduleProductionSingleVehicle(VehicleModel model)
        {
            var vehicleData = new VehicleAssemblyData
            {
                Status = Enums.ProductionStatus.ScheduledForProduction,
                Vehicle = new VehicleModel(model),
                VehicleAssemblyLogs = new List<EventLog>()
            };
            AddAssemblyLog(vehicleData, ProductionLogType.ProductionScheduled);
            _assemblyVehiclesList.Add(vehicleData);
            _dataStorage.Serialize(vehicleData, vehicleData.Vehicle.VehicleId.ToString());
            _logger.LogMessage($"Production scheduled for: { model.Model }");
        }

        public void SendVehiclesToAssemblyLine()
        {
            foreach (var vehicleData in _assemblyVehiclesList.Where(x => x.Status == Enums.ProductionStatus.ScheduledForProduction))
            {
                ProduceSingleVehicle(vehicleData);
            }
        }

        private void ProduceSingleVehicle(VehicleAssemblyData vehicleAssemblyData)
        {
            vehicleAssemblyData.SetNextStatus();
            AddAssemblyLog(vehicleAssemblyData, ProductionLogType.ProductionStarted);
            _dataStorage.Serialize(vehicleAssemblyData, vehicleAssemblyData.Vehicle.VehicleId.ToString());
            _logger.LogMessage($"Production started for: { vehicleAssemblyData.Vehicle.Model }");
        }

        public void ShipCompletedVehiclesWork()
        {
            while (true)
            {
                if (!_assemblyVehiclesList.Any(x => x.Status == Enums.ProductionStatus.Produced))
                {
                    _logger.LogMessage($"[THREAD2] Nothing for shipping yet ...");
                    Thread.Sleep(500);
                }
                else
                {
                    var vehicleForShipping = _assemblyVehiclesList.FirstOrDefault(x => x.Status == Enums.ProductionStatus.Produced);
                    ShipSingleVehicle(vehicleForShipping);
                    Thread.Sleep(_random.Next(1000));
                }
            }
        }

        private void ShipSingleVehicle(VehicleAssemblyData vehicleAssemblyData)
        {
            vehicleAssemblyData.SetNextStatus();
            AddAssemblyLog(vehicleAssemblyData, ProductionLogType.VehicleShipped);
            _dataStorage.Serialize(vehicleAssemblyData, vehicleAssemblyData.Vehicle.VehicleId.ToString());
            _logger.LogMessage($"[THREAD2] Shipping: { vehicleAssemblyData.Vehicle.Model }");
        }

        public void ProduceVehicleWork()
        {
            while (true)
            {
                if (!_assemblyVehiclesList.Any(x => x.Status == Enums.ProductionStatus.InProduction))
                {
                    _logger.LogMessage($"[THREAD] Nothing in production yet ...");
                    Thread.Sleep(500);
                }
                else
                {
                    var vehicleForProduction = _assemblyVehiclesList.FirstOrDefault(x => x.Status == Enums.ProductionStatus.InProduction);
                    ProduceVehicle(vehicleForProduction);
                    Thread.Sleep(_random.Next(500));
                }
            }
        }

        private void ProduceVehicle(VehicleAssemblyData vehicleAssemblyData)
        {
            GetPartsForProduction(vehicleAssemblyData);
            vehicleAssemblyData.SetNextStatus();
            AddAssemblyLog(vehicleAssemblyData, ProductionLogType.ProductionCompleted);
            _dataStorage.Serialize(vehicleAssemblyData, vehicleAssemblyData.Vehicle.VehicleId.ToString());
            _logger.LogMessage($"[THREAD] Prodction completed for: { vehicleAssemblyData.Vehicle.Model }");
        }

        private void AddAssemblyLog(VehicleAssemblyData vehicleAssemblyData, 
            ProductionLogType logType, string description = null)
        {
            vehicleAssemblyData.VehicleAssemblyLogs.Add(new EventLog
            {
                Type = logType,
                Description = description,
                CreationDateTime = DateTime.Now
            });
        }

        /// <summary>
        /// This normally would return parts, but its not yet implemented
        /// </summary>
        private void GetPartsForProduction(VehicleAssemblyData vehicleAssemblyData)
        {
            while (_random.Next(500) > 100)
            {
                AddAssemblyLog(vehicleAssemblyData, ProductionLogType.DelayInReceivingParts,
                "No parts available ... waiting");
                _logger.LogMessage($"[THREAD2] Parts delay ...");
                Thread.Sleep(500);
            }
            AddAssemblyLog(vehicleAssemblyData, ProductionLogType.PartsReceived);
            _logger.LogMessage($"[THREAD2] Parts received ...");
        }

        public void ExportLogsWork()
        {
            while (true)
            {
                if (!_assemblyVehiclesList.Any(x => x.Status == Enums.ProductionStatus.Shipped))
                {
                    _logger.LogMessage($"[THREAD3] Nothing to export ...");
                    Thread.Sleep(5000);
                }
                else
                {
                    var shipppedVehicle = _assemblyVehiclesList.FirstOrDefault(x => x.Status == ProductionStatus.Shipped);
                    var vehicleLog = _dataStorage.Load(shipppedVehicle.Vehicle.VehicleId.ToString());
                    _exportLogsService.ExportLogs(vehicleLog);
                    _assemblyVehiclesList.Remove(shipppedVehicle);
                }
            }
        }
    }
}
