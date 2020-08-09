using AutofacWebApi.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AutofacWebApi.FileManager
{
    class FileManagerConcrete : IFileManager
    {
        public FileManagerConcrete()
        {
        }

        public string Read(string filePath, string cacheItemName = "")
        {
            //Read all lines
            return File.ReadAllText(filePath);
        }

        public void Write(string filePath, string item)
        {
            //Write to file
            using (StreamWriter outputFile = new StreamWriter(filePath + "_A"))
            {
                outputFile.WriteLine(item + "\nA");
            }
        }
    }
}