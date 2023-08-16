using ContactBookWebApp.Domain.Entities;
using ContactWebApp.Shared.RequestParameter.Common;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<PagedList<Contact>> GetAllContacts(ContactRequestInputParameter parameter);
        Task<Contact> GetContactById(int id);
        Task<Contact> GetContactByEmail(string email);
    }
}
