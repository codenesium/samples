using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiVStateProvinceCountryRegionModelMapper
	{
		ApiVStateProvinceCountryRegionResponseModel MapRequestToResponse(
			int stateProvinceID,
			ApiVStateProvinceCountryRegionRequestModel request);

		ApiVStateProvinceCountryRegionRequestModel MapResponseToRequest(
			ApiVStateProvinceCountryRegionResponseModel response);

		JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> CreatePatch(ApiVStateProvinceCountryRegionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fa948a3cce306e9958586ba20fcf96f1</Hash>
</Codenesium>*/