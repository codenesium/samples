using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IProjectRepository
	{
		Task<Project> Create(Project item);

		Task Update(Project item);

		Task Delete(string id);

		Task<Project> Get(string id);

		Task<List<Project>> All(int limit = int.MaxValue, int offset = 0);

		Task<Project> ByName(string name);

		Task<Project> BySlug(string slug);

		Task<List<Project>> ByDataVersion(byte[] dataVersion);

		Task<List<Project>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id);
	}
}

/*<Codenesium>
    <Hash>0a8a94bcb45611e6ba417c60a3681e52</Hash>
</Codenesium>*/