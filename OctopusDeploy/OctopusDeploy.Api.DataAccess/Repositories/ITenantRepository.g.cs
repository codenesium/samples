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

                Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0);

                Task<Tenant> GetName(string name);
                Task<List<Tenant>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>cfd3f38e3f688d394d8451b6ec11f9ea</Hash>
</Codenesium>*/