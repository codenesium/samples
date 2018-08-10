using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesOrderDetailRepository
	{
		Task<SalesOrderDetail> Create(SalesOrderDetail item);

		Task Update(SalesOrderDetail item);

		Task Delete(int salesOrderID);

		Task<SalesOrderDetail> Get(int salesOrderID);

		Task<List<SalesOrderDetail>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderDetail>> ByProductID(int productID);

		Task<SpecialOfferProduct> GetSpecialOfferProduct(int productID);

		Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID);
	}
}

/*<Codenesium>
    <Hash>211444295a4a02fda38e7c9c3a5ea43f</Hash>
</Codenesium>*/