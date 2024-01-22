using CarStream.Service.Impl;
using CarStream.Repository.Impl;
using System;
using System.IO;
using CarStream.Entity;
using System.Xml.Serialization;
using CarStream.Data_Transfer_Objects;

namespace CarStream
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService car = new CarService();
            //car.CreateCar("e760a2ce-ba57-4010-8aa9-ae3c322e7a1f");
            //car.CreateCar("e760a2ce-ba57-4010-8aa9-ae3c322e7a1f");
            //car.CreateCar("e760a2ce-ba57-4010-8aa9-ae3c322e7a1a");
            //car.CreateCar("e760a57-4010-8aa9-ae3c322e7a1f");
            //car.AddCars();
            //List<Car> cars = car.GetCars();

            //foreach (var item in cars)
            //{
            //    Console.WriteLine(item.Color);

            //}
            CarDto carDto = new CarDto
            {
                Color = "Red",
                CarNumber = 1234,
                ProducedAt = DateTime.Now
            };
            car.DeleteCar("d07367e1-e3e1-4a35-aa24-872e919784a7");
        }
    }
}
