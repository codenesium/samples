using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IProjectGroupRepository
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
    <Hash>3fc098842fb0b04665a184c707aac6e8</Hash>
</Codenesium>*/