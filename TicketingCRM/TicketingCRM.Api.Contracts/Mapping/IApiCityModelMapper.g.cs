using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiCityModelMapper
	{
		ApiCityResponseModel MapRequestToResponse(
			int id,
			ApiCityRequestModel request);

		ApiCityRequestModel MapResponseToRequest(
			ApiCityResponseModel response);

		JsonPatchDocument<ApiCityRequestModel> CreatePatch(ApiCityRequestModel model);
	}
}

/*<Codenesium>
    <Hash>19962490bb65b06d2c43cff521182e89</Hash>
</Codenesium>*/