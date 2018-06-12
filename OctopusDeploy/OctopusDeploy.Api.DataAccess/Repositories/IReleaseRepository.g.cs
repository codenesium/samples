using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IReleaseRepository
        {
                Task<Release> Create(Release item);

                Task Update(Release item);

                Task Delete(string id);

                Task<Release> Get(string id);

                Task<List<Release>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Release> GetVersionProjectId(string version, string projectId);
                Task<List<Release>> GetIdAssembled(string id, DateTime assembled);
                Task<List<Release>> GetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId);
                Task<List<Release>> GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTime assembled);
                Task<List<Release>> GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTime assembled);
        }
}

/*<Codenesium>
    <Hash>b7c36c3fd6d70a164142392e817de53b</Hash>
</Codenesium>*/