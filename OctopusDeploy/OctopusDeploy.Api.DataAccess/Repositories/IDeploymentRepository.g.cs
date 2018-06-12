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

                Task<List<Deployment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Deployment>> GetChannelId(string channelId);
                Task<List<Deployment>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTime created, string releaseId, string taskId, string environmentId);
                Task<List<Deployment>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>b5b70f8b4342c4f0d3f95dc68475d7c7</Hash>
</Codenesium>*/