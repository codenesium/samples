using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDeploymentHistoryRepository
	{
		Task<DeploymentHistory> Create(DeploymentHistory item);

		Task Update(DeploymentHistory item);

		Task Delete(string deploymentId);

		Task<DeploymentHistory> Get(string deploymentId);

		Task<List<DeploymentHistory>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<DeploymentHistory>> ByCreated(DateTimeOffset created);
	}
}

/*<Codenesium>
    <Hash>167866f3f7afcb43096b7d415ce68e26</Hash>
</Codenesium>*/