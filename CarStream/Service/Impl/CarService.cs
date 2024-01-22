using System.Drawing;
using CarStream.Data_Transfer_Objects;
using CarStream.Entity;
using CarStream.Repository.Impl;
using CarStream.Service.Interfaces;

namespace CarStream.Service.Impl
{
    public class CarService : ICarService
    {
        private List<Car> cars;

        private ModelRepository modelRepository;

        private CarRepository garage;

        private readonly string filePath = Path.Combine(Environment.CurrentDirectory, "models.xml");

        private readonly string path = Path.Combine(Environment.CurrentDirectory, "cars.xml");

        public CarService()
        {
            modelRepository = new ModelRepository();
            garage = new CarRepository();
            cars = new List<Car>();
        }

        public void CreateCar(string modelId)
        {
            try
            {
                Car newCar = new Car()
                {
                    CarNumber = GenerateCarNumber(),
                    Color = GetColor(),
                    ProducedAt = new DateTime(2023, 12, 25),
                    ModelId = GetModelId(modelId)
                };
                if (newCar.ModelId != null)
                {
                    newCar.ModelName = GetModelNameById(newCar.ModelId);
                    cars.Add(newCar);
                }
                else
                {
                    Console.WriteLine("model doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void AddCars()
        {
            garage.SaveCars(cars, path);
        }

        private int GenerateCarNumber()
        {
            Random random = new Random();

            return random.Next(1000, 10000);
        }

        public List<Car> GetCars()
        {
            return cars;
        }

        public Guid? GetModelId(string modelId)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "models.xml");
            List<Model> loadedModels = modelRepository.LoadModels(filePath);

            var foundModel = loadedModels.FirstOrDefault(item => item.id.Equals(Guid.Parse(modelId)));

            if (foundModel != null)
            {
                Console.WriteLine($"Found Model Id: {foundModel.id}");

                return foundModel.id;
            }

            Console.WriteLine("Model not found!");

            return null;
        }

        private string GetColor()
        {
            List<string> colors = new List<string>() { "Red", "Blue", "White", "Black", "Orange", "Indigo" };
            var random = new Random();
            int index = random.Next(colors.Count);

            return colors[index];
        }

        public string? GetModelNameById(Guid? mid)
        {
            List<Model> loadedModels = modelRepository.LoadModels(filePath);
            var foundModel = loadedModels.FirstOrDefault(item => item.id.Equals(mid));
            if (foundModel != null)
            {
                Console.WriteLine($"Found Modelname: {foundModel.ModelName}");

                return foundModel.ModelName;
            }

            return null;
        }

        public Guid GetRandomModelId()
        {
            List<Model> loadedModels = modelRepository.LoadModels(filePath);
            List<Guid> guids = new List<Guid>();
            foreach (var item in loadedModels)
            {
                guids.Add(item.id);
            }
            var random = new Random();
            int index = random.Next(guids.Count);

            return guids[index];
        }

        public void EditCar(string selectedId, CarDto newCar)
        {
            List<Car> allCars = garage.LoadCars(path);
            try
            {
                var editing = allCars.FirstOrDefault(item => item.Id.Equals(Guid.Parse(selectedId)));
                Console.WriteLine($"Editing car is {editing.ModelName}");
                editing.Color = newCar.Color;
                editing.CarNumber = newCar.CarNumber;
                editing.ProducedAt = newCar.ProducedAt;
                editing.ModelId = GetRandomModelId();
                editing.ModelName = GetModelNameById(editing.ModelId);
                garage.SaveCars(allCars, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteCar(string id)
        {
            try
            {
                List<Car> allCars = garage.LoadCars(path);
                var filteredCars = allCars.Where(car => car.Id != Guid.Parse(id)).ToList();
                garage.SaveCars(filteredCars, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete the car because {ex.Message}");
            }
        }
    }
}