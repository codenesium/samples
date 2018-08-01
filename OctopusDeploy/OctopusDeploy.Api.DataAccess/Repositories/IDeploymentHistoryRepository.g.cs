using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IDeploymentHistoryRepository
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
    <Hash>9d3c42a846117cdab0aa86b7e92fcaa7</Hash>
</Codenesium>*/