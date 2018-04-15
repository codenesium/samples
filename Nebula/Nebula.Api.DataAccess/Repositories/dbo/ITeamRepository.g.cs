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

		ApiResponse GetById(int id);

		POCOTeam GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f39a59cc80ee0ac89d1992f8c1a6a7f3</Hash>
</Codenesium>*/