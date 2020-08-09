using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacWebApi.Contracts
{
    interface IFileManager
    {
        string Read(string filePath, string cacheItemName = "");
        void Write(string filePath, string item);
    }
}
