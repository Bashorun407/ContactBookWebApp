using ContactBookWebApp.Domain.Dto.UserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRequestDto userRequestDto);

    }
}
