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

		Task<POCOPurchaseOrderDetail> Get(int purchaseOrderID);

		Task<List<POCOPurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPurchaseOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>0b6660b606b20231a80ca3ca84b318b3</Hash>
</Codenesium>*/