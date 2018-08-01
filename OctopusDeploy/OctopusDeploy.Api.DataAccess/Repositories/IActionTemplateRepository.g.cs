using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IActionTemplateRepository
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
    <Hash>91d99c9327a79a7e0762d5978bb5b1f0</Hash>
</Codenesium>*/