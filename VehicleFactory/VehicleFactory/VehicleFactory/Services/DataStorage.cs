using System.IO;
using System.Xml.Serialization;
using VehicleFactory.Abstract;
using VehicleFactory.Models;

namespace VehicleFactory.Services
{
    public class DataStorage : IDataStorage<VehicleAssemblyData>
    {
        private static readonly object _lockObject = new object();

        private readonly string _filesLocation;
        public DataStorage(string filesLocation)
        {
            _filesLocation = filesLocation;
        }

        public VehicleAssemblyData Load(string filename)
        {
            lock (_lockObject)
            {
                var filePath = Path.Combine(_filesLocation, filename);
                var xmlSerializer = new XmlSerializer(typeof(VehicleAssemblyData));

                var content = File.ReadAllText(filePath);
                var stringReader = new StringReader(content);
                return (VehicleAssemblyData)xmlSerializer.Deserialize(stringReader);
            }
        }
        public void Serialize(VehicleAssemblyData obj, string filename)
        {
            lock (_lockObject)
            {
                var filePath = Path.Combine(_filesLocation, filename);
                var xmlSerializer = new XmlSerializer(obj.GetType());
                using (var textWriter = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(textWriter, obj);
                    textWriter.Close();
                }
            }
        }
    }
}
