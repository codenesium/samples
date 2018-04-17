using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOTeam
	{
		Task<CreateResponse<int>> Create(
			TeamModel model);

		Task<ActionResponse> Update(int id,
		                            TeamModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOTeam GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9bcded717d5e299f7410f4f98d794323</Hash>
</Codenesium>*/