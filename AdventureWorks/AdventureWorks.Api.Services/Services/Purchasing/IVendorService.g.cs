using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVendorService
	{
		Task<CreateResponse<ApiVendorResponseModel>> Create(
			ApiVendorRequestModel model);

		Task<UpdateResponse<ApiVendorResponseModel>> Update(int businessEntityID,
		                                                     ApiVendorRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiVendorResponseModel> Get(int businessEntityID);

		Task<List<ApiVendorResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiVendorResponseModel> ByAccountNumber(string accountNumber);

		Task<List<ApiProductVendorResponseModel>> ProductVendorsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2bde61c4701853f239991a55a287fe07</Hash>
</Codenesium>*/