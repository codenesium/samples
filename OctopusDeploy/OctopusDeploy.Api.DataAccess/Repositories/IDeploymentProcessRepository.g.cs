using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDeploymentProcessRepository
	{
		Task<DeploymentProcess> Create(DeploymentProcess item);

		Task Update(DeploymentProcess item);

		Task Delete(string id);

		Task<DeploymentProcess> Get(string id);

		Task<List<DeploymentProcess>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8009f92946ab51e3c1c9b017b4887e37</Hash>
</Codenesium>*/