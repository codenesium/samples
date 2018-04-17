using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkStatus
	{
		Task<CreateResponse<int>> Create(
			LinkStatusModel model);

		Task<ActionResponse> Update(int id,
		                            LinkStatusModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLinkStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLinkStatus> GetWhereDirect(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>85157fb8b11958459b9cb2e11a409896</Hash>
</Codenesium>*/