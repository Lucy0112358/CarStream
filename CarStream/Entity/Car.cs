using CarStream.Repository.Impl;

namespace CarStream.Entity
{
    public class Car
    {
        public string Color { get; set; }

        public Guid? ModelId { get; set; }

        public Guid? Id { get; set; }

        public int CarNumber { get; set; }

        public string? ModelName { get; set; }

        public DateTime ProducedAt { get; set; }

        private ModelRepository modelRepository;

        public Car()
        {
            modelRepository = new ModelRepository();
            Id = Guid.NewGuid();
        }
    }
}
