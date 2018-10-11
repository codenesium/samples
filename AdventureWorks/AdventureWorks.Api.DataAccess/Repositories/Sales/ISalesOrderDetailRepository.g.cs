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

		Task<List<SalesOrderDetail>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<SpecialOfferProduct> SpecialOfferProductByProductID(int productID);

		Task<SalesOrderHeader> SalesOrderHeaderBySalesOrderID(int salesOrderID);

		Task<SpecialOfferProduct> SpecialOfferProductBySpecialOfferID(int specialOfferID);
	}
}

/*<Codenesium>
    <Hash>3b415994a453d28d9e43e4110fca3be7</Hash>
</Codenesium>*/