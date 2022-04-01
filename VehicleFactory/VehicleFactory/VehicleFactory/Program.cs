using System;
using System.Threading;
using VehicleFactory.Services;

namespace VehicleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var dataStorage = new DataStorage(@"C:\Projects\Others\ZSL\zsl\VehicleFactory\VehicleFactory\VehicleFactory\Data\");
            var exportLogsService = new FakeExportLogsService();
            var assemblyLineService = new VehicleAssemblyService(logger, dataStorage, exportLogsService);

            var productionThread = new Thread(assemblyLineService.ProduceVehicleWork);
            productionThread.Start();

            var shippingThread = new Thread(assemblyLineService.ShipCompletedVehiclesWork);
            shippingThread.Start();

            var exportLogsThread = new Thread(assemblyLineService.ExportLogsWork);
            exportLogsThread.Start();
            

            //TODO: Add menu
            //1: add new model (get name from console)
            //2: send for production
            //3: send to assembly line

            assemblyLineService.AddNewModel("Octavia");
            assemblyLineService.AddNewModel("Octavia");
            assemblyLineService.AddNewModel("Superb");
            assemblyLineService.AddNewModel("Fabia");

            assemblyLineService.ScheduleProduction("Octavia", 20);
            assemblyLineService.ScheduleProduction("Kodiaq", 5);

            assemblyLineService.SendVehiclesToAssemblyLine();

            Console.ReadKey();
        }
    }
}
