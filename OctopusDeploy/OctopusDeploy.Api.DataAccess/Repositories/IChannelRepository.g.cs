using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IChannelRepository
	{
		Task<Channel> Create(Channel item);

		Task Update(Channel item);

		Task Delete(string id);

		Task<Channel> Get(string id);

		Task<List<Channel>> All(int limit = int.MaxValue, int offset = 0);

		Task<Channel> ByNameProjectId(string name, string projectId);

		Task<List<Channel>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);

		Task<List<Channel>> ByProjectId(string projectId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0a598a777ff0d880131bff965bdd00af</Hash>
</Codenesium>*/