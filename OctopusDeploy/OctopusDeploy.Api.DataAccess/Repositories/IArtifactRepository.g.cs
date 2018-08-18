using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IArtifactRepository
	{
		Task<Artifact> Create(Artifact item);

		Task Update(Artifact item);

		Task Delete(string id);

		Task<Artifact> Get(string id);

		Task<List<Artifact>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Artifact>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eb9ccff2467b4a4fbd3eed2ab208a524</Hash>
</Codenesium>*/