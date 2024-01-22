using System.Xml.Serialization;
using CarStream.Entity;
using CarStream.Repository.Interfaces;

namespace CarStream.Repository.Impl
{
    public class CarRepository : ICarRepository
    {
        public CarRepository()
        {
        }
        public void SaveCars(List<Car> cars, string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Car>));

            using (FileStream stream = File.Create(filePath))
            {
                xs.Serialize(stream, cars);
            }
        }

        public List<Car> LoadCars(string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Car>));

            using (FileStream xmlLoad = File.Open(filePath, FileMode.Open))
            {
                List<Car> loadedCars = (List<Car>)xs.Deserialize(xmlLoad);
                return loadedCars;
            }
        }

    }
}

