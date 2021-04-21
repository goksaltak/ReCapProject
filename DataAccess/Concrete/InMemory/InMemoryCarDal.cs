using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear="2019",DailyPrice=189000,Description="Prestige Plus"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear="2017",DailyPrice=134000,Description="Cosmo"},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear="2021",DailyPrice=249000,Description="Icon"},
                new Car{Id=4,BrandId=3,ColorId=1,ModelYear="2020",DailyPrice=209000,Description="Lounge"},
                new Car{Id=5,BrandId=4,ColorId=2,ModelYear="2011",DailyPrice=78000,Description="Active"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarByBrandDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByBrandDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByColorAndBrandDetails(int colorid, int brandid)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByColorDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByColorDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
        public List<RentalDetailDto> RentalDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
