using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		Task<POCOPurchaseOrderDetail> Create(ApiPurchaseOrderDetailModel model);

		Task Update(int purchaseOrderID,
		            ApiPurchaseOrderDetailModel model);

		Task Delete(int purchaseOrderID);

		Task<POCOPurchaseOrderDetail> Get(int purchaseOrderID);

		Task<List<POCOPurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPurchaseOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>8076d58f74b60082af39f30bd6c02fa4</Hash>
</Codenesium>*/