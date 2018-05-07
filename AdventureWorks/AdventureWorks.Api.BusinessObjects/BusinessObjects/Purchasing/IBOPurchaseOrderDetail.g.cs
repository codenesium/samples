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
		Task<CreateResponse<int>> Create(
			PurchaseOrderDetailModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            PurchaseOrderDetailModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		POCOPurchaseOrderDetail Get(int purchaseOrderID);

		List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2fd76cc7dfb6ad4935fb5c0f6db4d2d2</Hash>
</Codenesium>*/