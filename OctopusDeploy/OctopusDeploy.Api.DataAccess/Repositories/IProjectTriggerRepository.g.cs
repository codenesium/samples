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

		Task<List<ProjectTrigger>> ByProjectId(string projectId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>46ebb0668c1574ecc150ceb38f7a2475</Hash>
</Codenesium>*/