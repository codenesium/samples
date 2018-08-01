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

		Task<List<Artifact>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>a96759b570117e7d06958e5e229122f0</Hash>
</Codenesium>*/