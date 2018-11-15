using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCountryRegionServerModelMapper
	{
		ApiCountryRegionServerResponseModel MapServerRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel request);

		ApiCountryRegionServerRequestModel MapServerResponseToRequest(
			ApiCountryRegionServerResponseModel response);

		ApiCountryRegionClientRequestModel MapServerResponseToClientRequest(
			ApiCountryRegionServerResponseModel response);

		JsonPatchDocument<ApiCountryRegionServerRequestModel> CreatePatch(ApiCountryRegionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b4946324c7a2d493f186bc3da497d668</Hash>
</Codenesium>*/