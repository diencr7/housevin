using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HouseVin.Utility
{
    public class UploadedFile
    {

        public static string UploadedImage(IWebHostEnvironment webHostEnvironment, IFormFile fileImage)
        {
            string uniqueFileName = null;

            if (fileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
