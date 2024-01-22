using System.Xml.Serialization;
using CarStream.Entity;

namespace CarStream.Repository.Impl
{
    public class BrandRepository
    {
        public BrandRepository()
        {
        }

        public void SaveBrands(List<Brand> brands, string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Brand>));

            using (FileStream stream = File.Create(filePath))
            {
                xs.Serialize(stream, brands);
            }
        }

        public List<Brand> LoadBrands(string filePath)
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                Console.WriteLine("Error: XML file is empty or does not exist.");

                return new List<Brand>();
            }

            var xs = new XmlSerializer(typeof(List<Brand>));

            try
            {
                using (FileStream xmlLoad = File.Open(filePath, FileMode.Open))
                {
                    var collection = (List<Brand>)xs.Deserialize(xmlLoad);
                    return collection;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");

                return new List<Brand>();
            }
        }
    }
}
