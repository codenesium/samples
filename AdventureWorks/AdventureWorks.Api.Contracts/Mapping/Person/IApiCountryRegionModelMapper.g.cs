using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCountryRegionModelMapper
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
    <Hash>38738e9d081b1f5408f7e97b44c98192</Hash>
</Codenesium>*/