using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentRepository
        {
                Task<Deployment> Create(Deployment item);

                Task Update(Deployment item);

                Task Delete(string id);

                Task<Deployment> Get(string id);

                Task<List<Deployment>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Deployment>> GetChannelId(string channelId);
                Task<List<Deployment>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId);
                Task<List<Deployment>> GetTenantId(string tenantId);

                Task<List<DeploymentRelatedMachine>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4610f6dd09a9837bb901609ba4d0f9f8</Hash>
</Codenesium>*/