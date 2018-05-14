using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		POCOTeam Create(ApiTeamModel model);

		void Update(int id,
		            ApiTeamModel model);

		void Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOTeam Name(string name);
	}
}

/*<Codenesium>
    <Hash>cf855a74a476f178c860b5f5c3cd07e4</Hash>
</Codenesium>*/