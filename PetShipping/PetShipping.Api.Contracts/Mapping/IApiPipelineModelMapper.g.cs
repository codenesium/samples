using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineModelMapper
	{
		ApiPipelineResponseModel MapRequestToResponse(
			int id,
			ApiPipelineRequestModel request);

		ApiPipelineRequestModel MapResponseToRequest(
			ApiPipelineResponseModel response);

		JsonPatchDocument<ApiPipelineRequestModel> CreatePatch(ApiPipelineRequestModel model);
	}
}

/*<Codenesium>
    <Hash>62bff34ece9779f0fad5de8a8eb7d496</Hash>
</Codenesium>*/