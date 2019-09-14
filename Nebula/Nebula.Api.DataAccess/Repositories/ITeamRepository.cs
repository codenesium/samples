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

		Task<List<Team>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Team> ByName(string name);

		Task<List<Chain>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);

		Task<Organization> OrganizationByOrganizationId(int organizationId);
	}
}

/*<Codenesium>
    <Hash>8ee3a52476ca5a05d49c99c497307c2f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/