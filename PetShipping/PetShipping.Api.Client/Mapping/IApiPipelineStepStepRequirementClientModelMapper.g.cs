using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepStepRequirementModelMapper
	{
		ApiPipelineStepStepRequirementClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStepRequirementClientRequestModel request);

		ApiPipelineStepStepRequirementClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStepRequirementClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>01b2ee9af946b3381bc02b1762097239</Hash>
</Codenesium>*/