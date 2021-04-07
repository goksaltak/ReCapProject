using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, TakwindContext>, IRentalDal
    {
        public List<RentalDetailDto> RentalDetails()
        {
            using (TakwindContext context = new TakwindContext())
            {
                var result = from r in context.Rentals
                             join b in context.Brand
                             on r.CarId equals b.Id
                             join c in context.Customers
                             on r.CustomerId equals c.UserId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.Name,
                                 CustomerId = r.CustomerId,
                                 CustomerName = c.CompanyName
                             };
                return result.ToList();

            }
        }
    }
}
