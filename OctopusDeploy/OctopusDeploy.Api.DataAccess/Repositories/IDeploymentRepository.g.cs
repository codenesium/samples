using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDeploymentRepository
	{
		Task<Deployment> Create(Deployment item);

		Task Update(Deployment item);

		Task Delete(string id);

		Task<Deployment> Get(string id);

		Task<List<Deployment>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Deployment>> ByChannelId(string channelId, int limit = int.MaxValue, int offset = 0);

		Task<List<Deployment>> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Deployment>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<DeploymentRelatedMachine>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3940520e2a12615ae92ffe1c0d87e1e6</Hash>
</Codenesium>*/