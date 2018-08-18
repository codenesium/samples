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
    <Hash>d64d74e6ecbdecf0daef0ce610f7772b</Hash>
</Codenesium>*/