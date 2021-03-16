using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}

            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 8400, ModelYear = "2019", Description = "Duster 1.3 130 Bg Prestige Plus 4x4" });
            //carManager.Delete(new Car { Id = 2 });
        }
    }
}
