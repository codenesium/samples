using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>ed61933b08cf55a08758efb1a0962207</Hash>
</Codenesium>*/