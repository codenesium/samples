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
    <Hash>ac07de063950f4f747b233996872bfbb</Hash>
</Codenesium>*/