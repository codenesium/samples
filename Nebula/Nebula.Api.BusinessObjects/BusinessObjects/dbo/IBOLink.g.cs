using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLink
	{
		Task<CreateResponse<int>> Create(
			LinkModel model);

		Task<ActionResponse> Update(int id,
		                            LinkModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLink GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>666f913aea47a4fb81e2a11a239d4bf4</Hash>
</Codenesium>*/