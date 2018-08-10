using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductVendorModelMapper
	{
		ApiProductVendorResponseModel MapRequestToResponse(
			int productID,
			ApiProductVendorRequestModel request);

		ApiProductVendorRequestModel MapResponseToRequest(
			ApiProductVendorResponseModel response);

		JsonPatchDocument<ApiProductVendorRequestModel> CreatePatch(ApiProductVendorRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bf36d690fa4c76629f7c3d51ae433ce2</Hash>
</Codenesium>*/