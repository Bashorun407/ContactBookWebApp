using ContactBookWebApp.Domain.Dto.UserDto;
using ContactBookWebApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using ContactWebApp.Shared.RequestParameter.Common;

namespace ContactBookWebApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData paginData)>> GetAllUsers(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> GetUserById(string id);
        Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email);
        Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string id);
        Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file);
    }
}
