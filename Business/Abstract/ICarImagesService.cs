﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IResult Add(CarImages carImages, IFormFile file);
        IResult Delete(CarImages carImages);
        IResult Update(CarImages carImages, IFormFile file);
        IDataResult<CarImages> Get(int id);
    }
}

