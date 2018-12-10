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

		Task<List<Chain>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<Organization> OrganizationByOrganizationId(int organizationId);
	}
}

/*<Codenesium>
    <Hash>dbc70bcdd2030e9e6a950b2aea9d24c6</Hash>
</Codenesium>*/