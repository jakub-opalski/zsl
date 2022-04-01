using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFactory.Models;

namespace VehicleFactory.Abstract
{
    public interface IExportLogsService
    {
        void ExportLogs(VehicleAssemblyData vehicleAssemblyData);
    }
}
