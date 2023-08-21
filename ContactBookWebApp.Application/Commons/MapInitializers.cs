using AutoMapper;
using ContactBookWebApp.Domain.Dto.ContactDto;
using ContactBookWebApp.Domain.Dto.UserDto;
using ContactBookWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application
{
    public class MapInitializers : Profile
    {
        public MapInitializers()
        {
            CreateMap<UserEntity, UserResponseDto>();
            CreateMap<UserRequestDto, UserEntity>();
            CreateMap<Contact, ContactResponseDto>();
            CreateMap<ContactRequestDto, Contact>();
        }
    }
}
