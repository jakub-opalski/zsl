using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFactory.Abstract;
using VehicleFactory.Models;

namespace VehicleFactory.Services
{
    public class FakeExportLogsService : IExportLogsService
    {
        private ILogger _logger;

        public FakeExportLogsService()
        {
            _logger = new ConsoleLogger();
        }

        public void ExportLogs(VehicleAssemblyData vehicleAssemblyData)
        {
            _logger.LogMessage($"Data exporeted for vehicle ${ vehicleAssemblyData.Vehicle.VehicleId }");
        }
    }
}
