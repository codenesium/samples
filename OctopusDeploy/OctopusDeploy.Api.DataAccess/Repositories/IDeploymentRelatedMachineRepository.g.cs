using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDeploymentRelatedMachineRepository
	{
		Task<DeploymentRelatedMachine> Create(DeploymentRelatedMachine item);

		Task Update(DeploymentRelatedMachine item);

		Task Delete(int id);

		Task<DeploymentRelatedMachine> Get(int id);

		Task<List<DeploymentRelatedMachine>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<DeploymentRelatedMachine>> ByDeploymentId(string deploymentId);

		Task<List<DeploymentRelatedMachine>> ByMachineId(string machineId);

		Task<Deployment> GetDeployment(string deploymentId);
	}
}

/*<Codenesium>
    <Hash>5f0e0dad40761b6dedaa7a9f4836463f</Hash>
</Codenesium>*/