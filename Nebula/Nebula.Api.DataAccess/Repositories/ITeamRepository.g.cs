using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		Task<Team> Create(Team item);

		Task Update(Team item);

		Task Delete(int id);

		Task<Team> Get(int id);

		Task<List<Team>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b79c1075fdb0918ba6a9f95595c19fca</Hash>
</Codenesium>*/