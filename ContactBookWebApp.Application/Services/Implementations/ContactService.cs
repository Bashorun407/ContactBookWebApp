using AutoMapper;
using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto;
using ContactBookWebApp.Domain.Dto.ContactDto;
using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.UoW.Abstraction;
using ContactWebApp.Shared.RequestParameter.Common;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Application.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<ContactResponseDto>> CreateContact(ContactRequestDto contactRequestDto)
        {
            var contact = _mapper.Map<Contact>(contactRequestDto);
            _unitOfWork.ContactRepository.Create(contact);
            await _unitOfWork.SaveAsync();
            var contactResponse = _mapper.Map<ContactResponseDto>(contact);

            return StandardResponse<ContactResponseDto>.Success("Successfully created new contact", contactResponse, 201);
        }

        public async Task<StandardResponse<ContactResponseDto>> DeleteContact(int id)
        {
            _logger.LogInformation($"Checking if contact with id {id} exists");
            var contact = await _unitOfWork.ContactRepository.GetContactById(id);
            if (contact is null)
            {
                _logger.LogError("Contact not found in the database. Aborting delete");
                return StandardResponse<ContactResponseDto>.Failed("Contact not found in the database");
            }
            _unitOfWork.ContactRepository.Delete(contact);
            await _unitOfWork.SaveAsync();
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardResponse<ContactResponseDto>.Success($"Successfully deleted a contact: {contact.FirstName}", contactDto, 200);

        }

        public async Task<StandardResponse<(IEnumerable<ContactResponseDto>, MetaData)>> GetAllContacts(ContactRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ContactRepository.GetAllContacts(parameter);
            var contactsDtos = _mapper.Map<IEnumerable<ContactResponseDto>>(result);
            return StandardResponse<(IEnumerable<ContactResponseDto>, MetaData)>.Success("Successfully retrieved all contacts", (contactsDtos, result.MetaData), 200);

        }

        public async Task<StandardResponse<ContactResponseDto>> GetContactByEmail(string email)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactByEmail(email);
            var contactDto = _mapper.Map<ContactResponseDto>(contact);

            return StandardResponse<ContactResponseDto>.Success("Successfully retrieved contact by email", contactDto, 200);
        }

        public async Task<StandardResponse<ContactResponseDto>> GetContactById(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactById(id);
            var contactDto = _mapper.Map<ContactResponseDto>(contact);

            return StandardResponse<ContactResponseDto>.Success("Successfully retrieved contact by id", contactDto, 200);
        }

        public async Task<StandardResponse<ContactResponseDto>> UpdateContact(int id, ContactRequestDto contactRequestDto)
        {
            var contactExists = await _unitOfWork.ContactRepository.GetContactById(id);

            if(contactExists == null)
            {
                _logger.LogError("Contact not found in the database. Aborting update");
                return StandardResponse<ContactResponseDto>.Failed("Contact not found in the database");

            }

            var contact = _mapper.Map<Contact>(contactRequestDto);
            _unitOfWork.ContactRepository.Update(contact);
            _unitOfWork.SaveAsync();

            var contactDto = _mapper.Map<ContactResponseDto>(contact);

            return StandardResponse<ContactResponseDto>.Success("Contact has been updated successfully", contactDto, 200);
        }
    }
}
