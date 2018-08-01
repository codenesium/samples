using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiClientModelMapper
	{
		ApiClientResponseModel MapRequestToResponse(
			int id,
			ApiClientRequestModel request);

		ApiClientRequestModel MapResponseToRequest(
			ApiClientResponseModel response);

		JsonPatchDocument<ApiClientRequestModel> CreatePatch(ApiClientRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2884c3917735f2d01c3c620017ef0908</Hash>
</Codenesium>*/