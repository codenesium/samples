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

		POCOSalesOrderDetail Get(int salesOrderID);

		List<POCOSalesOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3fafe6565096198eab5d9cff0fa59ac4</Hash>
</Codenesium>*/