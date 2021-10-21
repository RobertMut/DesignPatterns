using System;
using System.Linq;
using DesignPatterns.UnitOfWork.Entities;

namespace DesignPatterns.UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityContext context = new EntityContext();
            UnitOfWork unit = new UnitOfWork(context);
            unit.CarRepository.Add(new Car
            {
                Brand = "Opel",
                Model = "Astra",
                Plate = "11111"
            });
            unit.OwnerRepository.Add(new Owner
            {
                Name = "John",
                Surname = "Smith",
                Plate = "11111",
            });
            var firstCar = unit.CarRepository.GetAll().First();
            var firstOwner = unit.OwnerRepository.GetAll().First();
            Console.WriteLine($"{firstCar.Model} {firstCar.Brand} {firstCar.Plate}");
            Console.WriteLine($"{firstOwner.Name} {firstOwner.Surname} {firstOwner.Plate}");
        }
    }
}
