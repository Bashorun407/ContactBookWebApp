using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using ContactWebApp.Shared.RequestParameter.Common;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.RepositoryBase.Implementations
{
    public class UserEntityRepository : Repository<UserEntity>, IUserEntityRepository
    {
        private readonly DbSet<UserEntity> _context;

        public UserEntityRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context.Set<UserEntity>();
        }

        public async Task<PagedList<UserEntity>> GetAllUsers(UserRequestInputParameter parameter)
        {
            var result = await _context.Where(u=> u.FirstName.ToLower()
            .Contains(parameter.SearchTerm, StringComparison.InvariantCultureIgnoreCase) 
            || u.LastName.ToLower().Contains(parameter.SearchTerm, StringComparison.InvariantCultureIgnoreCase)
            || u.Email.ToLower().Contains(parameter.SearchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .ToListAsync();

            var count = await _context.CountAsync();

            return new PagedList<UserEntity>(result, count, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return await _context.Where(c => c.Email.Contains(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync();
        }

        public async Task<UserEntity> GetUserById(string id)
        {
            return await _context.FindAsync(id);
        }
    }
}
