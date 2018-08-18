using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPurchaseOrderDetailService
	{
		Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
			ApiPurchaseOrderDetailRequestModel model);

		Task<UpdateResponse<ApiPurchaseOrderDetailResponseModel>> Update(int purchaseOrderID,
		                                                                  ApiPurchaseOrderDetailRequestModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID);

		Task<List<ApiPurchaseOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderDetailResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>93c2b369c46db9054195023aed8dcdbb</Hash>
</Codenesium>*/