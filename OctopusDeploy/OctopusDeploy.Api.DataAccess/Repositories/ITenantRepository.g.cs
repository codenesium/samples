using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITenantRepository
        {
                Task<Tenant> Create(Tenant item);

                Task Update(Tenant item);

                Task Delete(string id);

                Task<Tenant> Get(string id);

                Task<List<Tenant>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Tenant> GetName(string name);
                Task<List<Tenant>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>d1d0793f1d58d5aa85dd98248846c64e</Hash>
</Codenesium>*/