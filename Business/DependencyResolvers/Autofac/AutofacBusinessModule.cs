using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<CustomersManager>().As<ICustomersService>();
            builder.RegisterType<EfCustomersDal>().As<ICustomersDal>();
            builder.RegisterType<RentalsManager>().As<IRentalsService>();
            builder.RegisterType<EfRentalsDal>().As<IRentalsDal>();
            builder.RegisterType<UsersManager>().As<IUsersService>();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>();
            builder.RegisterType<CarImagesManager>().As<ICarImagesService>();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
