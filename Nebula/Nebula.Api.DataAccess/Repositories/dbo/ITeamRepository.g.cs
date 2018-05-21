using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		Task<POCOTeam> Create(ApiTeamModel model);

		Task Update(int id,
		            ApiTeamModel model);

		Task Delete(int id);

		Task<POCOTeam> Get(int id);

		Task<List<POCOTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOTeam> Name(string name);
	}
}

/*<Codenesium>
    <Hash>8cfd43b94076c4fd46ea9d977f325959</Hash>
</Codenesium>*/