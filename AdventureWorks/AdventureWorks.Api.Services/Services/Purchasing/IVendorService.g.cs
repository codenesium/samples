using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVendorService
	{
		Task<CreateResponse<ApiVendorServerResponseModel>> Create(
			ApiVendorServerRequestModel model);

		Task<UpdateResponse<ApiVendorServerResponseModel>> Update(int businessEntityID,
		                                                           ApiVendorServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiVendorServerResponseModel> Get(int businessEntityID);

		Task<List<ApiVendorServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiVendorServerResponseModel> ByAccountNumber(string accountNumber);

		Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>452de7efa47e9857d66ce6f1db32b1f9</Hash>
</Codenesium>*/