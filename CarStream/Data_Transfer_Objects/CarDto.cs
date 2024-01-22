
using System;
namespace CarStream.Data_Transfer_Objects
{
    public class CarDto
    {
        public string Color { get; set; }

        public int CarNumber { get; set; }

        public DateTime ProducedAt { get; set; }

        public CarDto()
        {
        }
    }
}

