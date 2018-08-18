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
    <Hash>9bf4bc622b024c7126e1fe84a49825a4</Hash>
</Codenesium>*/