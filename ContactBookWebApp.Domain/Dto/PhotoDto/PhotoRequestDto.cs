using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Domain.Dto.PhotoDto
{
     public class PhotoRequestDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
    }
}
