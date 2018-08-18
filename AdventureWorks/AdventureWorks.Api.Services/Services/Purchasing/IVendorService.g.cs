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

		Task<List<ApiProductVendorResponseModel>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b24fa7119b1a4b0d27e527ab103351a1</Hash>
</Codenesium>*/