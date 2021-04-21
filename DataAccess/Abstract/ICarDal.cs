using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarByColorDetails(int id);
        List<CarDetailDto> GetCarByBrandDetails(int id);
        List<CarDetailDto> GetCarByDetails(int id);
        List<CarDetailDto> GetCarByColorAndBrandDetails(int colorid, int brandid);

    }
}
