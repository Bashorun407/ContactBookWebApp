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
    public class UserEntityRepository : Repository<UserEntity>, IUserEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public UserEntityRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
