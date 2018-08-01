using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IActionTemplateVersionRepository
	{
		Task<ActionTemplateVersion> Create(ActionTemplateVersion item);

		Task Update(ActionTemplateVersion item);

		Task Delete(string id);

		Task<ActionTemplateVersion> Get(string id);

		Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset = 0);

		Task<ActionTemplateVersion> ByNameVersion(string name, int version);

		Task<List<ActionTemplateVersion>> ByLatestActionTemplateId(string latestActionTemplateId);
	}
}

/*<Codenesium>
    <Hash>ac1e5c2e48a8440844e75b685613722f</Hash>
</Codenesium>*/