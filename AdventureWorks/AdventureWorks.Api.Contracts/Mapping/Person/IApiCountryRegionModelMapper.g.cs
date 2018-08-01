using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCountryRegionModelMapper
	{
		ApiCountryRegionResponseModel MapRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionRequestModel request);

		ApiCountryRegionRequestModel MapResponseToRequest(
			ApiCountryRegionResponseModel response);

		JsonPatchDocument<ApiCountryRegionRequestModel> CreatePatch(ApiCountryRegionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>de52a4fb7d9c3e18d13fd316430ccc6d</Hash>
</Codenesium>*/