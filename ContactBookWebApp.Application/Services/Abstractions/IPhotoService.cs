using ContactBookWebApp.Domain.Dto.PhotoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Abstractions
{
    public interface IPhotoService
    {
        void AddPhotoForUser(int userId, PhotoRequestDto photoRequestDto);
    }
}
