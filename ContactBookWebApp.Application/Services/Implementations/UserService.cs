using AutoMapper;
using ContactBookWebApp.Application.Services.Abstractions;
using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto;
using ContactBookWebApp.Domain.Dto.UserDto;
using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.UoW.Abstraction;
using ContactWebApp.Shared.RequestParameter.Common;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPhotoService _photoService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
           
        }

        public async Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto)
        {
            _logger.LogInformation("Creating user");
            var user = _mapper.Map<UserEntity>(userRequestDto);
            _logger.LogInformation("Adding user to the database");
            await _unitOfWork.UserEntityRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"User {user.Id} saved to the database successfully");
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("User created successfully", userDto, 201);
        }

        public async Task<StandardResponse<UserResponseDto>> DeleteUser(string id)
        {
            _logger.LogInformation($"Checking if user with id {id} exists");
            var user = await _unitOfWork.UserEntityRepository.GetUserById(id);
            if (user is null)
            {
                _logger.LogError("User not found in the database. Aborting delete");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }
            _unitOfWork.UserEntityRepository.Delete(user);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"Successfully deleted a user {user.FirstName}", userDto, 200);
        }

        public async Task<StandardResponse<(IEnumerable<UserResponseDto>, MetaData)>> GetAllUsers(UserRequestInputParameter parameter)
        {
            var result = await _unitOfWork.UserEntityRepository.GetAllUsers(parameter);
            var usersDtos = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            return StandardResponse<(IEnumerable<UserResponseDto>, MetaData)>.Success("Successfully retrieved all users", (usersDtos, result.MetaData), 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UserEntityRepository.GetUserByEmail(email);
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);

        }

        public async Task<StandardResponse<UserResponseDto>> GetUserById(string id)
        {
            var user = await _unitOfWork.UserEntityRepository.GetUserById(id);
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto)
        {
            var userExists = await _unitOfWork.UserEntityRepository.GetUserById(id);
            if (userExists is null)
            {
                _logger.LogError("User not found in the database. Aborting update");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }
            var user = _mapper.Map<UserEntity>(userRequestDto);
            _unitOfWork.UserEntityRepository.Update(user);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"Successfully deleted a user {user.FirstName}", userDto, 200);

        }

        public async Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file)
        {
            /*var user = await _unitOfWork.UserEntityRepository.GetUserById(userId);
            if (user is null)
            {
                _logger.LogWarning($"No user with id {userId}");
                return StandardResponse<(bool, string)>.Failed("No user found", 406);
            }
            string url = _photoService.AddPhotoForUser(userId, file);
            if (string.IsNullOrWhiteSpace(url))
                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);
            user.ImageURL = url;
            _unitOfWork.UserEntityRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (false, url), 204);*/

            return null;

        }
    }
}
