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

		Task<List<DeploymentHistory>> ByCreated(DateTimeOffset created, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>716d8fdb19fe30a803f0e75f8909361d</Hash>
</Codenesium>*/