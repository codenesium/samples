using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepDestinationModelMapper
	{
		ApiPipelineStepDestinationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepDestinationClientRequestModel request);

		ApiPipelineStepDestinationClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepDestinationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3050832969ed019dd418f3f13ed2284c</Hash>
</Codenesium>*/