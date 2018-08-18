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
    <Hash>d90a4eecdff595179f5b8e930334cb46</Hash>
</Codenesium>*/