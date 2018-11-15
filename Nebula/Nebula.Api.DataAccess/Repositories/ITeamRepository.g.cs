using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ITeamRepository
	{
		Task<Team> Create(Team item);

		Task Update(Team item);

		Task Delete(int id);

		Task<Team> Get(int id);

		Task<List<Team>> All(int limit = int.MaxValue, int offset = 0);

		Task<Team> ByName(string name);

		Task<Organization> OrganizationByOrganizationId(int organizationId);

		Task<List<Team>> ByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0);

		Task<Chain> CreateChain(Chain item);

		Task DeleteChain(Chain item);
	}
}

/*<Codenesium>
    <Hash>70b5a0319873624dc192aaa594ef5a90</Hash>
</Codenesium>*/