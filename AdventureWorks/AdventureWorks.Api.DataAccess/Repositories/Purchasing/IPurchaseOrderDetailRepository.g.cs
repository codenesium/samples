using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
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
    <Hash>3a3e24279ef74e55534607d182d5470e</Hash>
</Codenesium>*/