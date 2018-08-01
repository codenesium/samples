using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiRateModelMapper
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
    <Hash>fc1a61d5eb333c527e397e1e2f875c75</Hash>
</Codenesium>*/