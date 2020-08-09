using AutofacWebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacWebApi.Decorators.Concrete
{
    abstract class FileManagerDecorator : IFileManager
    {
        private readonly IFileManager _fileManager;

        public FileManagerDecorator(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public virtual string Read(string filePath, string cacheItemName = "")
        {
            return _fileManager.Read(filePath, cacheItemName);
        }

        public virtual void Write(string filePath, string item)
        {
            _fileManager.Write(filePath, item);
        }
    }
}