using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		int Create(TeamModel model);

		void Update(int id,
		            TeamModel model);

		void Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5fa4256d2418a4fac9ab95ced8ecf1d0</Hash>
</Codenesium>*/