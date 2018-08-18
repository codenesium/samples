using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IProjectRepository
	{
		Task<Project> Create(Project item);

		Task Update(Project item);

		Task Delete(string id);

		Task<Project> Get(string id);

		Task<List<Project>> All(int limit = int.MaxValue, int offset = 0);

		Task<Project> ByName(string name);

		Task<Project> BySlug(string slug);

		Task<List<Project>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);

		Task<List<Project>> ByDiscreteChannelReleaseId(bool discreteChannelRelease, string id, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ac1b5e2ce9900dbbb063c4ff42164ff6</Hash>
</Codenesium>*/