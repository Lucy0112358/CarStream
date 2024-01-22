using System;
using System.Reflection;
using CarStream.Data_Transfer_Objects;
using CarStream.Entity;
using CarStream.Repository.Impl;
using CarStream.Service.Interfaces;

namespace CarStream.Service.Impl
{
    public class BrandService : IBrandService
    {
        private List<Brand> brands;

        private BrandRepository brandRepository;
        private ModelRepository models;

        private string filePath = Path.Combine(Environment.CurrentDirectory, "brands.xml");
        private string path = Path.Combine(Environment.CurrentDirectory, "models.xml");

        public BrandService()
        {
            brandRepository = new BrandRepository();
            models = new ModelRepository();
            brands = new List<Brand>();
        }

        public void CreateBrand(string name)
        {
            Brand newBrand = new Brand(name)
            {
                BrandName = name,
            };

            brands.Add(newBrand);
        }

        public void AddBrands()
        {
            brandRepository.SaveBrands(brands, filePath);
        }

        public void Update(string id, BrandDto request)
        {
            try
            {
                List<Brand> allBrands = brandRepository.LoadBrands(filePath);
                var selected = allBrands.SingleOrDefault(item => item.id.Equals(Guid.Parse(id)));
                if (selected != null)
                {
                    selected.BrandName = request.name;
                    brandRepository.SaveBrands(allBrands, filePath);
                }
                else
                {
                    Console.WriteLine("Wrong id");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                List<Brand> allBrands = brandRepository.LoadBrands(filePath);
                var selected = allBrands.SingleOrDefault(item => item.id.Equals(Guid.Parse(id)));
                var filteredList = allBrands.Where(item => item.id != Guid.Parse(id)).ToList();
                brandRepository.SaveBrands(filteredList, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Brand> Read()
        {
            List<Brand> list = brandRepository.LoadBrands(filePath);

            return list;
        }

        public List<Model> GetModelsById(string id)
        {
            // I intentionally skipped error-handling here, might add later
            var collection = models.LoadModels(path);
            var list = collection.Where(item => item.BrandId.Equals(Guid.Parse(id))).ToList();

            return list;
        }
    }
}

