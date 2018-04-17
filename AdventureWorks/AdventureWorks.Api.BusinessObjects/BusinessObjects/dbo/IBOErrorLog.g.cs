using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOErrorLog
	{
		Task<CreateResponse<int>> Create(
			ErrorLogModel model);

		Task<ActionResponse> Update(int errorLogID,
		                            ErrorLogModel model);

		Task<ActionResponse> Delete(int errorLogID);

		ApiResponse GetById(int errorLogID);

		POCOErrorLog GetByIdDirect(int errorLogID);

		ApiResponse GetWhere(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>36a4aeb84ced415858d9e0dfe5ff7d5d</Hash>
</Codenesium>*/