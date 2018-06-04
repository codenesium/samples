using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		Task<PurchaseOrderDetail> Create(PurchaseOrderDetail item);

		Task Update(PurchaseOrderDetail item);

		Task Delete(int purchaseOrderID);

		Task<PurchaseOrderDetail> Get(int purchaseOrderID);

		Task<List<PurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<PurchaseOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>9fa03a1d0a927454531d77d450a494e2</Hash>
</Codenesium>*/