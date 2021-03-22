using Business.Concrete;
using Core.Entities.Concrete;
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
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}


            CarCreate();
            //carManager.Delete(new Car { Id = 2 });
            //CarListele();
            //CarUpdate();
            //CarUpdate();
            //ColorAdd();
            //ColorDelete();
            //BrandCreate();
            //CarTest();
            //CarRead();
            //CustomerAdd();
            //UsersAdd();
            //RentalAdd();

        }

        private static void RentalAdd()
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            rentalsManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = DateTime.Now });
        }

        private static void UsersAdd()
        {
            UserManager usersManager = new UserManager(new EfUserDal());
            //usersManager.Add(new User { Id = 1, FirstName = "Trendyol", LastName = "Pazaryeri", Email = "info@trendyol.com", Password = "12345" });
            //usersManager.Add(new User { Id = 2, FirstName = "HepsiBurada", LastName = "Pazaryeri", Email = "info@HepsiBurada.com", Password = "12345" });
            //usersManager.Add(new User { Id = 3, FirstName = "N11", LastName = "Pazaryeri", Email = "info@N11.com", Password = "12345" });
            //usersManager.Add(new User { Id = 4, FirstName = "Amazon", LastName = "Pazaryeri", Email = "info@Amazon.com", Password = "12345" });
            //usersManager.Add(new User { Id = 5, FirstName = "GittiGidiyor", LastName = "Pazaryeri", Email = "info@GittiGidiyor.com", Password = "12345" });
            //usersManager.Add(new User { Id = 6, FirstName = "EPttAvm", LastName = "Pazaryeri", Email = "info@EPttAvm.com", Password = "12345" });
            //usersManager.Add(new User { Id = 7, FirstName = "Çiçek Sepeti", LastName = "Pazaryeri", Email = "info@Çiçek Sepeti.com", Password = "12345" });
        }

        private static void CustomerAdd()
        {
            CustomerManager customersManager = new CustomerManager(new EfCustomerDal());
            customersManager.Add(new Customer { CompanyName = "Trendyol" });
            customersManager.Add(new Customer { CompanyName = "HepsiBurada" });
            customersManager.Add(new Customer { CompanyName = "N11" });
            customersManager.Add(new Customer { CompanyName = "Amazon" });
            customersManager.Add(new Customer { CompanyName = "GittiGidiyor" });
            customersManager.Add(new Customer { CompanyName = "EPttAvm" });
            customersManager.Add(new Customer { CompanyName = "Çiçek Sepeti" });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine(cars.BrandName + " " + cars.ColorName + " " + cars.Description + " " + cars.DailyPrice);
                }
            }

        }

        private static void CarRead()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }

        }

        private static void BrandCreate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Fiat" });
            brandManager.Add(new Brand { Name = "BMW" });
            brandManager.Add(new Brand { Name = "AUDI" });
            brandManager.Add(new Brand { Name = "Scania" });
            brandManager.Add(new Brand { Name = "VolksWagen" });
        }

        private static void ColorDelete()
        {
            ColorManager colorManager = new Business.Concrete.ColorManager(new EfColorDal());
            colorManager.Delete(new Color { Id = 9 });
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new Business.Concrete.ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Bordo" });
            colorManager.Add(new Color { Name = "Mavi" });
            colorManager.Add(new Color { Name = "Kırmızı" });
            colorManager.Add(new Color { Name = "Beyaz" });
        }

        private static void CarDelete()
        {

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 1003 });
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 1004, Description = "Corolla Avensis", ColorId = 61, ModelYear = "2000", DailyPrice = 95 });
        }

        private static void CarCreate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 195, ModelYear = "2013", Description = "Business 1.5 Dci" });
        }
    }
}
