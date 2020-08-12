using AutofacWebApi.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Web;

namespace AutofacWebApi.Decorators.Concrete
{
    class CacheDecorator : FileManagerDecorator
    {
        private readonly MemoryCache _memCache;

        public CacheDecorator(IFileManager fileManager) : base(fileManager)
        {
            _memCache = new MemoryCache("MemCache");
        }

        public override string Read(string filePath, string cacheItemName = "")
        {
            //Read all lines
            string cacheItemValue = File.ReadAllText(filePath);

            //Caching
            if (!_memCache.Contains(cacheItemName))
            {
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(100)
                };
                _memCache.Add(cacheItemName, cacheItemValue, policy);
            }
            /*File.Delete(filePath);*/
            Thread.Sleep(3000);

            return (string)_memCache.GetCacheItem(cacheItemName).Value;
        }
    }
}