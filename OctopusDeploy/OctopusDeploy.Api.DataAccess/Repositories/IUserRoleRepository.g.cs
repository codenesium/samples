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

                Task<List<UserRole>> All(int limit = int.MaxValue, int offset = 0);

                Task<UserRole> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>ec5282c13aa55006bf7c2beab984089f</Hash>
</Codenesium>*/