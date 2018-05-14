using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		POCOTeam Create(TeamModel model);

		void Update(int id,
		            TeamModel model);

		void Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOTeam Name(string name);
	}
}

/*<Codenesium>
    <Hash>2b0cda60579f64edc7e63bc2fc86d117</Hash>
</Codenesium>*/