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

		Task<List<Team>> ByMachineId(int machineId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>48f4fa2b175dd58db2cf80e463d3c33c</Hash>
</Codenesium>*/