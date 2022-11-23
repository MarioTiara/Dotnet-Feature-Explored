using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Services
{
    public class LocalFileStorage : ILocalFileStorage
    {
        private readonly IHostingEnvironment _env;
        public LocalFileStorage(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task StoreFile(IFormFile file, string key)
        {
            const string rootPath = "PhotoStore";
            var folder = $"{_env.WebRootPath}\\{rootPath}\\{key}";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            var fullpath = $"{folder}\\{Path.GetFileName(file.FileName)}";
            using (var targetStream = new FileStream(fullpath, FileMode.Create))
            {
                await file.CopyToAsync(targetStream);
                targetStream.Close();
            }
        }
    }
}
