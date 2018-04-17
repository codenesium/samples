using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderDetail
	{
		Task<CreateResponse<int>> Create(
			SalesOrderDetailModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            SalesOrderDetailModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		ApiResponse GetById(int salesOrderID);

		POCOSalesOrderDetail GetByIdDirect(int salesOrderID);

		ApiResponse GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderDetail> GetWhereDirect(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6388f617b522fe63269f075582a18e29</Hash>
</Codenesium>*/