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

		Task<List<Chain>> Chains(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<Organization> OrganizationByOrganizationId(int organizationId);
	}
}

/*<Codenesium>
    <Hash>02927bb9463c7e736d05ae82715ffda6</Hash>
</Codenesium>*/