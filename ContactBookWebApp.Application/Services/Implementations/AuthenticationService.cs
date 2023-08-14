using AutoMapper;
using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto.UserDto;
using ContactBookWebApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<UserEntity> userManager, IConfiguration config)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }

        public async Task<IdentityResult> RegisterUser(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<UserEntity>(userRequestDto);
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRequestDto.Role);
            }
            return result;
        }
    }
}
