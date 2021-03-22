using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImages, IFormFile file);
        IResult Delete(CarImage carImages);
        IResult Update(CarImage carImages, IFormFile file);
        IDataResult<CarImage> Get(int id);
    }
}

