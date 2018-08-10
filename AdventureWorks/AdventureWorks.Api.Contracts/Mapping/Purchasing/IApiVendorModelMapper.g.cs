using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiVendorModelMapper
	{
		ApiVendorResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiVendorRequestModel request);

		ApiVendorRequestModel MapResponseToRequest(
			ApiVendorResponseModel response);

		JsonPatchDocument<ApiVendorRequestModel> CreatePatch(ApiVendorRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7386c7f19e47650f981f39a076fcebb2</Hash>
</Codenesium>*/