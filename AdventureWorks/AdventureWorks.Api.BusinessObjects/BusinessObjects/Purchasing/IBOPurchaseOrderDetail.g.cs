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
		Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
			ApiPurchaseOrderDetailRequestModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            ApiPurchaseOrderDetailRequestModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID);

		Task<List<ApiPurchaseOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiPurchaseOrderDetailResponseModel>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>5994cdd23c0fa6b29e16273e94f9cd69</Hash>
</Codenesium>*/