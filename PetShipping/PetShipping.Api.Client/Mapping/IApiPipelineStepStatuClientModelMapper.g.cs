using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepStatuModelMapper
	{
		ApiPipelineStepStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStatuClientRequestModel request);

		ApiPipelineStepStatuClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>aa5bebb53401ac9802dc013ba467c35b</Hash>
</Codenesium>*/