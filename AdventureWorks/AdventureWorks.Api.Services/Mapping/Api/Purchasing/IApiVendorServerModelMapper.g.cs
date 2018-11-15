using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiVendorServerModelMapper
	{
		ApiVendorServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiVendorServerRequestModel request);

		ApiVendorServerRequestModel MapServerResponseToRequest(
			ApiVendorServerResponseModel response);

		ApiVendorClientRequestModel MapServerResponseToClientRequest(
			ApiVendorServerResponseModel response);

		JsonPatchDocument<ApiVendorServerRequestModel> CreatePatch(ApiVendorServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2ee2e2a331dedc61996482ee658c4b35</Hash>
</Codenesium>*/