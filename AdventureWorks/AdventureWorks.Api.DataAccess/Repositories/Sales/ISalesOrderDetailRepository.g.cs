using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		Task<POCOSalesOrderDetail> Create(ApiSalesOrderDetailModel model);

		Task Update(int salesOrderID,
		            ApiSalesOrderDetailModel model);

		Task Delete(int salesOrderID);

		Task<POCOSalesOrderDetail> Get(int salesOrderID);

		Task<List<POCOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOSalesOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>ffb3d6de1b865256da8d797a19abb119</Hash>
</Codenesium>*/