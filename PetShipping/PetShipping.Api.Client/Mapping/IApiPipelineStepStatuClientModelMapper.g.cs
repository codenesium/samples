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
    <Hash>9442dc010651a70221ceb929457e387b</Hash>
</Codenesium>*/