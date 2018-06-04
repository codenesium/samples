using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IPurchaseOrderDetailService
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
    <Hash>80d5619d10e73dfe749617c0bfb61ac1</Hash>
</Codenesium>*/