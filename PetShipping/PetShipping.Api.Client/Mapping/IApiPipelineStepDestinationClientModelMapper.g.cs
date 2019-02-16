using PetShippingNS.Api.Contracts;
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
    <Hash>c29514de32fa307681ac6e4eabcd243a</Hash>
</Codenesium>*/