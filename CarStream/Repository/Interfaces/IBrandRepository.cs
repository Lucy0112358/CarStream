using System.Collections.Generic;
using CarStream.Entity;

namespace CarStream.Repository.Interfaces
{
    public interface IBrandRepository
    {
        void SaveBrands(List<Brand> brands, string filePath);
        List<Brand> LoadBrands(string filePath);
    }
}
