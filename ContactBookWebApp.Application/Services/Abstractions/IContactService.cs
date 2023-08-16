using ContactBookWebApp.Domain.Dto.ContactDto;
using ContactBookWebApp.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using ContactWebApp.Shared.RequestParameter.Common;

namespace ContactBookWebApp.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<StandardResponse<(IEnumerable<ContactResponseDto> contacts, MetaData pagingData)>> GetAllContacts(ContactRequestInputParameter parameter);
        Task<StandardResponse<ContactResponseDto>> GetContactById(int id);
        Task<StandardResponse<ContactResponseDto>> GetContactByEmail(string email);
        Task<StandardResponse<ContactResponseDto>> UpdateContact(int id, ContactRequestDto contactRequestDto);
        Task<StandardResponse<ContactResponseDto>> DeleteContact(int id);
        Task<StandardResponse<ContactResponseDto>> CreateContact(ContactRequestDto contactRequestDto);

    }
}
