using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		Task<DTOTeam> Create(DTOTeam dto);

		Task Update(int id,
		            DTOTeam dto);

		Task Delete(int id);

		Task<DTOTeam> Get(int id);

		Task<List<DTOTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOTeam> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ec70a4e8bdd7dd1c9fe0fe461cc7785b</Hash>
</Codenesium>*/