using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeaderSalesReason
	{
		Task<CreateResponse<int>> Create(
			SalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            SalesOrderHeaderSalesReasonModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		ApiResponse GetById(int salesOrderID);

		POCOSalesOrderHeaderSalesReason GetByIdDirect(int salesOrderID);

		ApiResponse GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeaderSalesReason> GetWhereDirect(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6d2384c39f1b2a72a29f43cbda986779</Hash>
</Codenesium>*/