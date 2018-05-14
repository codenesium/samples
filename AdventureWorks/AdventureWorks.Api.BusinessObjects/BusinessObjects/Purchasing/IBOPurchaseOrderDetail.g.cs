using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPurchaseOrderDetail
	{
		Task<CreateResponse<POCOPurchaseOrderDetail>> Create(
			ApiPurchaseOrderDetailModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            ApiPurchaseOrderDetailModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		POCOPurchaseOrderDetail Get(int purchaseOrderID);

		List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderDetail> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>f5d95fdbbf641d02fdb3d3cce9125931</Hash>
</Codenesium>*/