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
    public interface IUserEntityRepository : IRepository<UserEntity>
    {

        Task<PagedList<UserEntity>> GetAllUsers(UserRequestInputParameter parameter);
        Task<UserEntity> GetUserById(string id);
        Task<UserEntity> GetUserByEmail(string email);
    }
}
