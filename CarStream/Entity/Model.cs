using System;
namespace CarStream.Entity
{
    public class Model
    {
        public string ModelName { get; set; }

        public Guid id { get; set; }

        public Guid? BrandId { get; set; }

        public Model(string name)
        {
            ModelName = name;
            id = Guid.NewGuid();
        }
        public Model()
        {

        }
    }
}

