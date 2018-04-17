using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeader
	{
		Task<CreateResponse<int>> Create(
			SalesOrderHeaderModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            SalesOrderHeaderModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		ApiResponse GetById(int salesOrderID);

		POCOSalesOrderHeader GetByIdDirect(int salesOrderID);

		ApiResponse GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>28bd31d11d7520f618c49fbabbeac6dc</Hash>
</Codenesium>*/