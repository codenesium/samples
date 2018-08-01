using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IDeploymentProcessRepository
	{
		Task<DeploymentProcess> Create(DeploymentProcess item);

		Task Update(DeploymentProcess item);

		Task Delete(string id);

		Task<DeploymentProcess> Get(string id);

		Task<List<DeploymentProcess>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4d4a8cdcb2b8cc451d5fbe9c221c023a</Hash>
</Codenesium>*/