using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IReleaseRepository
	{
		Task<Release> Create(Release item);

		Task Update(Release item);

		Task Delete(string id);

		Task<Release> Get(string id);

		Task<List<Release>> All(int limit = int.MaxValue, int offset = 0);

		Task<Release> ByVersionProjectId(string version, string projectId);

		Task<List<Release>> ByIdAssembled(string id, DateTimeOffset assembled, int limit = int.MaxValue, int offset = 0);

		Task<List<Release>> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId, int limit = int.MaxValue, int offset = 0);

		Task<List<Release>> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled, int limit = int.MaxValue, int offset = 0);

		Task<List<Release>> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c8837507ad3559eb7602e9c751c328c7</Hash>
</Codenesium>*/