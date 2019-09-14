using PetShippingNS.Api.Contracts;
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
    <Hash>fd64edb017321744440087b4a89ebd96</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/