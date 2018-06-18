using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IArtifactRepository
        {
                Task<Artifact> Create(Artifact item);

                Task Update(Artifact item);

                Task Delete(string id);

                Task<Artifact> Get(string id);

                Task<List<Artifact>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Artifact>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>ac22740686493e7f89022c2be5ad3359</Hash>
</Codenesium>*/