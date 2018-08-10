using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ITeamRepository
	{
		Task<Team> Create(Team item);

		Task Update(Team item);

		Task Delete(string id);

		Task<Team> Get(string id);

		Task<List<Team>> All(int limit = int.MaxValue, int offset = 0);

		Task<Team> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>8a729bb35bb3ef43ccfc68f23a55c17c</Hash>
</Codenesium>*/