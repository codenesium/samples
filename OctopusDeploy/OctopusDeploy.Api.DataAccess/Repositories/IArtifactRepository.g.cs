using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>0723818bb2350e75c0703ce414b7fcf8</Hash>
</Codenesium>*/