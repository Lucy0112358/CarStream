using CarStream.Entity;
using CarStream.Repository.Impl;
using CarStream.Service.Interfaces;

namespace CarStream.Service.Impl
{
    public class ModelService : IModelService
    {
        private List<Model> models;

        private ModelRepository modelRepository;

        private BrandRepository brandRepository;

        private CarRepository carRepository;

        private string filePath = Path.Combine(Environment.CurrentDirectory, "models.xml");

        private string path = Path.Combine(Environment.CurrentDirectory, "cars.xml");

        public ModelService()
        {
            brandRepository = new BrandRepository();
            carRepository = new CarRepository();
            models = new List<Model>();
            modelRepository = new ModelRepository();
        }

        public void CreateModel(string name, Guid brandId)
        {
            Model newModel = new Model(name)
            {
                BrandId = brandId
            };

            models.Add(newModel);
        }

        public void AddModels()
        {
            modelRepository.SaveModels(models, filePath);
        }

        public Guid? GetBrandId(string id)
        {
            List<Brand> loadedBrands = brandRepository.LoadBrands(filePath);

            var foundBrand = loadedBrands.FirstOrDefault(item => item.id.Equals(Guid.Parse(id)));

            if (foundBrand != null)
            {
                Console.WriteLine($"Found Model Id: {foundBrand.id}");

                return foundBrand.id;
            }

            Console.WriteLine("Brand with such an id doesn't exist.");

            return null;
        }

        public List<Model> GetModels()
        {
            return models;
        }

        public List<Model> LoadModels(string filePath)
        {
            return modelRepository.LoadModels(filePath);
        }

        public Guid? SearchModels(string filePath, string guid)
        {
            List<Model> loadedModels = LoadModels(filePath);

            Console.WriteLine("Loaded Model IDs:");

            foreach (var item in loadedModels)
            {
                if (item.id.Equals(Guid.Parse(guid)))
                {
                    Console.WriteLine($"Found Model Id: {item.id}");

                    return item.id;
                }
            }

            Console.WriteLine("Model not found!");

            return null;
        }

        public List<Car> GetCarsById(string id)
        {
            // error handling might be added later
            var list = carRepository.LoadCars(path);
            var collection = list.Where(car => car.Id.Equals(Guid.Parse(id))).ToList();

            return collection;
        }
    }
}
