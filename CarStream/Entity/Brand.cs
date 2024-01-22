namespace CarStream.Entity
{
    public class Brand
    {
        public string BrandName { get; set; }

        public Guid id { get; private set; }

        public Brand(string name)
        {
            this.BrandName = name;
            this.id = Guid.NewGuid();
        }
    }
}

