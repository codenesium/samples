using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IProjectTriggerRepository
	{
		Task<ProjectTrigger> Create(ProjectTrigger item);

		Task Update(ProjectTrigger item);

		Task Delete(string id);

		Task<ProjectTrigger> Get(string id);

		Task<List<ProjectTrigger>> All(int limit = int.MaxValue, int offset = 0);

		Task<ProjectTrigger> ByProjectIdName(string projectId, string name);

		Task<List<ProjectTrigger>> ByProjectId(string projectId);
	}
}

/*<Codenesium>
    <Hash>1f9d0b9c3aef72f8e7c5de9661a5d726</Hash>
</Codenesium>*/