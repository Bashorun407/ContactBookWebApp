using ContactBookWebApp.Application.Services.Abstractions;
using ContactBookWebApp.Domain.Dto.PhotoDto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
       /* public IConfiguration Configuration { get; }
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;
        public PhotoService(IConfiguration configuration)
        {
            Configuration = configuration;
            _cloudinarySettings = new();
            var jwtSettings = Configuration.GetSection("CloudinarySettings");
            _cloudinarySettings.CloudName = jwtSettings["CloudName"];
            _cloudinarySettings.ApiKey = jwtSettings["ApiKey"];
            _cloudinarySettings.ApiSecret = jwtSettings["ApiSecret"];
            Account account = new Account(_cloudinarySettings.CloudName
                , _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }*/

        public void AddPhotoForUser(int userId, PhotoRequestDto photoRequestDto)
        {
            /* var uploadResult = new ImageUploadResult();
             if (file.Length > 0)
             {
                 using (var stream = file.OpenReadStream())
                 {
                     var uploadParams = new ImageUploadParams()
                     {
                         File = new FileDescription(file.Name, stream)
                     };
                     uploadResult = _cloudinary.Upload(uploadParams);
                 }
             }
             string url = uploadResult.Url.ToString();
             string publicId = uploadResult.PublicId;//work with this next time

             return url;
            */
        }
    }
}
