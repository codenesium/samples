using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IActionTemplateRepository
	{
		Task<ActionTemplate> Create(ActionTemplate item);

		Task Update(ActionTemplate item);

		Task Delete(string id);

		Task<ActionTemplate> Get(string id);

		Task<List<ActionTemplate>> All(int limit = int.MaxValue, int offset = 0);

		Task<ActionTemplate> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>7f54abd0f2e87cced8a9f4cc627898aa</Hash>
</Codenesium>*/