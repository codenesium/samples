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

		Task<List<Chain>> Chains(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<List<MachineRefTeam>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<Organization> GetOrganization(int organizationId);
	}
}

/*<Codenesium>
    <Hash>04fff6e787004757d9e3bb163ba081a3</Hash>
</Codenesium>*/