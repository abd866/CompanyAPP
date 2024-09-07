﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentPath
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            var folderPath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/File", folderName);
            var fileName=$"{file.FileName}-{Guid.NewGuid()}";
            var filePath = Path.Combine(folderPath, fileName);

            using var fileStream=new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }
    }
}
