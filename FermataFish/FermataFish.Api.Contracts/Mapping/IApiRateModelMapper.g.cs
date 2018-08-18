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
    <Hash>dd306824feee35106b8a5971774be533</Hash>
</Codenesium>*/