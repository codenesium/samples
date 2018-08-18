using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDeploymentEnvironmentRepository
	{
		Task<DeploymentEnvironment> Create(DeploymentEnvironment item);

		Task Update(DeploymentEnvironment item);

		Task Delete(string id);

		Task<DeploymentEnvironment> Get(string id);

		Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset = 0);

		Task<DeploymentEnvironment> ByName(string name);

		Task<List<DeploymentEnvironment>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ca93f6988d13259724c014ffdffb13eb</Hash>
</Codenesium>*/