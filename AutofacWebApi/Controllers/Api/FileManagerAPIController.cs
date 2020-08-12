using Autofac;
using AutofacWebApi.Contracts;
using AutofacWebApi.Decorators.Concrete;
using AutofacWebApi.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutofacWebApi.Controllers.Api
{
    public class FileManagerAPIController : ApiController
    {
        // GET: api/GetFromFile
        [HttpGet]
        public IHttpActionResult GetFromFile()
        {
            IFileManager fileManager = new FileManagerConcrete();
            string fileString = fileManager.Read(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FileRead.txt");
            fileManager.Write(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FileRead.txt", fileString);

            return Ok(fileString);
        }

        // GET: api/GetFromMemory
        [HttpGet]
        public IHttpActionResult GetFromMemory()
        {
            string fileString;

            using (var scope = WebApiApplication.container.BeginLifetimeScope())
            {
                IFileManager fileManager = scope.Resolve<IFileManager>();
                fileString = fileManager.Read(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FileRead.txt", "fileString");
                fileManager.Write(AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\FileRead.txt", fileString);
            }

            return Ok(fileString);
        }
    }
}
