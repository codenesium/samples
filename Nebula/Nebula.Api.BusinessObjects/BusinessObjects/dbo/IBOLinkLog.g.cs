using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkLog
	{
		Task<CreateResponse<int>> Create(
			LinkLogModel model);

		Task<ActionResponse> Update(int id,
		                            LinkLogModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLinkLog GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLinkLog> GetWhereDirect(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7bf03c23da4c27dc7aefb5314cb00467</Hash>
</Codenesium>*/