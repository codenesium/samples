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

                Task<List<Artifact>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Artifact>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>ec7b8bb23fbc1b14adb96da868453521</Hash>
</Codenesium>*/