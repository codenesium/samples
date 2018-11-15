using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPurchaseOrderHeaderService
	{
		Task<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>> Create(
			ApiPurchaseOrderHeaderServerRequestModel model);

		Task<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>> Update(int purchaseOrderID,
		                                                                        ApiPurchaseOrderHeaderServerRequestModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		Task<ApiPurchaseOrderHeaderServerResponseModel> Get(int purchaseOrderID);

		Task<List<ApiPurchaseOrderHeaderServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderServerResponseModel>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderServerResponseModel>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>06fc06dbdaf8cba9ce6554c062b4c351</Hash>
</Codenesium>*/