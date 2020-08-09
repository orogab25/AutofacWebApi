using Autofac;
using AutofacWebApi.Contracts;
using AutofacWebApi.Decorators.Concrete;
using AutofacWebApi.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacWebApi
{
    public static class AutofacSetup
    {
        public static IContainer Init()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Regisztrációs rész
            builder.RegisterType<FileManagerConcrete>().As<IFileManager>();
            builder.RegisterDecorator<CacheDecorator, IFileManager>();

            return builder.Build();
        }
    }
}