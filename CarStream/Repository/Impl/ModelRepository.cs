using System.Xml.Serialization;
using CarStream.Entity;
using CarStream.Repository.Interfaces;

namespace CarStream.Repository.Impl
{
    public class ModelRepository : IModelRepository
    {
        public ModelRepository()
        {
        }

        public void SaveModels(List<Model> models, string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Model>));

            using (FileStream stream = File.Create(filePath))
            {
                xs.Serialize(stream, models);
            }
        }

        public List<Model> LoadModels(string filePath)
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                Console.WriteLine("Error: XML file is empty or does not exist.");

                return new List<Model>();
            }

            var xs = new XmlSerializer(typeof(List<Model>));

            try
            {
                using (FileStream xmlLoad = File.Open(filePath, FileMode.Open))
                {
                    var collection = (List<Model>)xs.Deserialize(xmlLoad);
                    return collection;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");

                return new List<Model>();
            }
        }
    }
}
