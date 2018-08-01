using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiCityModelMapper
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
    <Hash>d9153061e89d83da5a82d53ec847c267</Hash>
</Codenesium>*/