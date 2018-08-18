using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IActionTemplateVersionRepository
	{
		Task<ActionTemplateVersion> Create(ActionTemplateVersion item);

		Task Update(ActionTemplateVersion item);

		Task Delete(string id);

		Task<ActionTemplateVersion> Get(string id);

		Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset = 0);

		Task<ActionTemplateVersion> ByNameVersion(string name, int version);

		Task<List<ActionTemplateVersion>> ByLatestActionTemplateId(string latestActionTemplateId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e58a013a4b27668755853822ca60df9f</Hash>
</Codenesium>*/