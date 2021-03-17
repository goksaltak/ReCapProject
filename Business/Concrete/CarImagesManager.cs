using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {

        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(CarImages carImages,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimited(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult();


        }

        public IResult Delete(CarImages carImages)
        {
            FileHelper.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), Messages.CarImagesListed);

        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(CarImages carImages, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimited(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(p => p.Id == carImages.Id).ImagePath;

            carImages.ImagePath = FileHelper.Update(oldPath, file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult();

        }
        private IResult CheckImageLimited(int carId)
        {
            var carImageCount = _carImagesDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >=5)
            {
                return new ErrorResult(Messages.carImageLimited);
            }
            return new SuccessResult(); 
        }
    }
}
