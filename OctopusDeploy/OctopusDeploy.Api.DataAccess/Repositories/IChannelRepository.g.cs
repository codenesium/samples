using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IChannelRepository
	{
		Task<Channel> Create(Channel item);

		Task Update(Channel item);

		Task Delete(string id);

		Task<Channel> Get(string id);

		Task<List<Channel>> All(int limit = int.MaxValue, int offset = 0);

		Task<Channel> ByNameProjectId(string name, string projectId);

		Task<List<Channel>> ByDataVersion(byte[] dataVersion);

		Task<List<Channel>> ByProjectId(string projectId);
	}
}

/*<Codenesium>
    <Hash>54eb6b395e5c34f3e68e3752bbefce4f</Hash>
</Codenesium>*/