using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiClientModelMapper
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
    <Hash>70f8ac0e746e68345ea3492c95f4624e</Hash>
</Codenesium>*/