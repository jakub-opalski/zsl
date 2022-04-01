using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFactory.Models
{
    public class VehicleModel
    {
        public Guid VehicleId { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public int NumberOfDoors { get; set; }

        public VehicleModel() { }
        public VehicleModel(VehicleModel model)
        {
            VehicleId = Guid.NewGuid();
            Model = model.Model;
        }
    }
}
