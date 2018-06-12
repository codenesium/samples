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

                Task<List<Artifact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Artifact>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>26e080b986beaf5181846f94a846e7ab</Hash>
</Codenesium>*/