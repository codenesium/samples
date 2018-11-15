using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepModelMapper
	{
		ApiPipelineStepClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepClientRequestModel request);

		ApiPipelineStepClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>011d6c280e255e22fe6f8fbee3be6c92</Hash>
</Codenesium>*/