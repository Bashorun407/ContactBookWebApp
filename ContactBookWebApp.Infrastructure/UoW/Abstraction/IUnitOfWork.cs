using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.UoW.Abstraction
{
    public interface IUnitOfWork
    {
        public IContactRepository ContactRepository { get; }
        public IUserEntityRepository UserEntityRepository { get; }

        Task SaveAsync();
        void Dispose();
    }
}
