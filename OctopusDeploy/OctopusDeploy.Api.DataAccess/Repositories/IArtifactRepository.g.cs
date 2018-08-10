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

		Task<List<Artifact>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>e6dc0260b7407cc29baee8b11430a3a1</Hash>
</Codenesium>*/