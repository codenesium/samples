using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		int Create(string name,
		           int organizationId);

		void Update(int id, string name,
		            int organizationId);

		void Delete(int id);

		Response GetById(int id);

		POCOTeam GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bf8865795114ecd182d88d3efcbc9fc5</Hash>
</Codenesium>*/