using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using ContactBookWebApp.Infrastructure.RepositoryBase.Implementations;
using ContactBookWebApp.Infrastructure.UoW.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.UoW.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContactRepository _contactRepository;
        private IUserEntityRepository _userEntityRepository;

        private readonly ApplicationDbContext _context;

        IContactRepository IUnitOfWork.ContactRepository => _contactRepository ?? new ContactRepository(_context);

        IUserEntityRepository IUnitOfWork.UserEntityRepository => _userEntityRepository ?? new UserEntityRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
