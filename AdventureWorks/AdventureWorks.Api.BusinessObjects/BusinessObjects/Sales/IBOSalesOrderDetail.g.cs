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
		Task<CreateResponse<POCOSalesOrderDetail>> Create(
			ApiSalesOrderDetailModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderDetailModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		POCOSalesOrderDetail Get(int salesOrderID);

		List<POCOSalesOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderDetail> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>aa119d64e577f414125a15da7bb0561c</Hash>
</Codenesium>*/