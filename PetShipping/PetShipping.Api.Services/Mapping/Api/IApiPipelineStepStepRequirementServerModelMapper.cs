using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStepRequirementServerModelMapper
	{
		ApiPipelineStepStepRequirementServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel request);

		ApiPipelineStepStepRequirementServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStepRequirementServerResponseModel response);

		ApiPipelineStepStepRequirementClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStepRequirementServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel> CreatePatch(ApiPipelineStepStepRequirementServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3719d66022a6202ecac288e39cb36c78</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/