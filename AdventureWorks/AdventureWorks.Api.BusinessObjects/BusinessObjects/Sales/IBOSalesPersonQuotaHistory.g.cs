using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPersonQuotaHistory
	{
		Task<CreateResponse<int>> Create(
			SalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5bb9452258ab81a160ccd37cba8b890c</Hash>
</Codenesium>*/