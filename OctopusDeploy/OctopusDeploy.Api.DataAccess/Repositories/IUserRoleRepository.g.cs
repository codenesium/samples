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

                Task<List<UserRole>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<UserRole> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>98e8c12ee5372c0d66f878211d958824</Hash>
</Codenesium>*/