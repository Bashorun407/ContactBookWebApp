using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using ContactWebApp.Shared.RequestParameter.Common;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.RepositoryBase.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly DbSet<Contact> _contacts;

        public ContactRepository(ApplicationDbContext context) : base(context)
        {
            _contacts = context.Set<Contact>();
        }
        public async Task<PagedList<Contact>> GetAllContacts(ContactRequestInputParameter parameter)
        {
            var result = await _contacts.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
            .ToListAsync();
            var count = await _contacts.CountAsync();
            return new PagedList<Contact>(result, count, parameter.PageNumber, parameter.PageSize);

        }

        public async Task<Contact> GetContactByEmail(string email)
        {
            return await _contacts.Where(c => c.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefaultAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contacts.FindAsync(id);
        }
    }
}
