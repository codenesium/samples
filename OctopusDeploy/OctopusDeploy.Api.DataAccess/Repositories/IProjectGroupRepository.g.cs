using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IProjectGroupRepository
	{
		Task<ProjectGroup> Create(ProjectGroup item);

		Task Update(ProjectGroup item);

		Task Delete(string id);

		Task<ProjectGroup> Get(string id);

		Task<List<ProjectGroup>> All(int limit = int.MaxValue, int offset = 0);

		Task<ProjectGroup> ByName(string name);

		Task<List<ProjectGroup>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>b4f1943224232b2a3bc0e9bde6a3b37a</Hash>
</Codenesium>*/