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

		Task<List<PurchaseOrderDetail>> ByProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>20da30d1150f78897440d54ed608bf9e</Hash>
</Codenesium>*/