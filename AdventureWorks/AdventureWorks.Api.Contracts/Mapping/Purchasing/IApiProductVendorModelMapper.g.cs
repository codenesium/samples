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
    <Hash>91b33a523b5d846aac252e0d731826b2</Hash>
</Codenesium>*/