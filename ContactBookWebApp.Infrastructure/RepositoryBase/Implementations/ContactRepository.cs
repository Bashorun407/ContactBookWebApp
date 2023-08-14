using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.RepositoryBase.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
