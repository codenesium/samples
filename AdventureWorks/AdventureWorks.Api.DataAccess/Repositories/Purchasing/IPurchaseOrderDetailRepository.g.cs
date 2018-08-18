using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPurchaseOrderDetailRepository
	{
		Task<PurchaseOrderDetail> Create(PurchaseOrderDetail item);

		Task Update(PurchaseOrderDetail item);

		Task Delete(int purchaseOrderID);

		Task<PurchaseOrderDetail> Get(int purchaseOrderID);

		Task<List<PurchaseOrderDetail>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PurchaseOrderDetail>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f774c637c0930b25d3c75d7ccaa50616</Hash>
</Codenesium>*/