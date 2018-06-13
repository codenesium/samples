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

                Task<List<Release>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Release> GetVersionProjectId(string version, string projectId);
                Task<List<Release>> GetIdAssembled(string id, DateTimeOffset assembled);
                Task<List<Release>> GetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId);
                Task<List<Release>> GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled);
                Task<List<Release>> GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled);
        }
}

/*<Codenesium>
    <Hash>9b28b7ec2af4bc7e5442857233c9007a</Hash>
</Codenesium>*/