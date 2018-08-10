using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiRateModelMapper
	{
		ApiRateResponseModel MapRequestToResponse(
			int id,
			ApiRateRequestModel request);

		ApiRateRequestModel MapResponseToRequest(
			ApiRateResponseModel response);

		JsonPatchDocument<ApiRateRequestModel> CreatePatch(ApiRateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c23e577a4060cd20ef412fe519ca4e7d</Hash>
</Codenesium>*/