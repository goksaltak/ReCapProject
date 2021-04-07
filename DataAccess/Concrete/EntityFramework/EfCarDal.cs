using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, TakwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (TakwindContext context = new TakwindContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join cl in context.Color
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Id=c.Id,
                                 ColorId = c.ColorId,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }

    }
}
