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

		Task<POCOSalesOrderDetail> Get(int salesOrderID);

		Task<List<POCOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOSalesOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>60badc2c5d2b990ac4e64f3efac8d1a1</Hash>
</Codenesium>*/