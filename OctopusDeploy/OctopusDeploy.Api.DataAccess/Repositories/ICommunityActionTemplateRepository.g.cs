using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ICommunityActionTemplateRepository
	{
		Task<CommunityActionTemplate> Create(CommunityActionTemplate item);

		Task Update(CommunityActionTemplate item);

		Task Delete(string id);

		Task<CommunityActionTemplate> Get(string id);

		Task<List<CommunityActionTemplate>> All(int limit = int.MaxValue, int offset = 0);

		Task<CommunityActionTemplate> ByExternalId(Guid externalId);

		Task<CommunityActionTemplate> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>630af5704d18f9b6d0b2722a1950cc32</Hash>
</Codenesium>*/