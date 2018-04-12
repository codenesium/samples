using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		int Create(
			string name,
			int organizationId);

		void Update(int id,
		            string name,
		            int organizationId);

		void Delete(int id);

		Response GetById(int id);

		POCOTeam GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3e096d8b67309d591f89ade2f6b8eee4</Hash>
</Codenesium>*/