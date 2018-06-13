using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IUserRoleRepository
        {
                Task<UserRole> Create(UserRole item);

                Task Update(UserRole item);

                Task Delete(string id);

                Task<UserRole> Get(string id);

                Task<List<UserRole>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<UserRole> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>5f7768579298af11508b4f767aa6c629</Hash>
</Codenesium>*/