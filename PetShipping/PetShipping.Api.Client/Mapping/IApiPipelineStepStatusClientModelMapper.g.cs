using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepStatusModelMapper
	{
		ApiPipelineStepStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStatusClientRequestModel request);

		ApiPipelineStepStatusClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ff77a0f107c5d764bebf9a8d2fbb3317</Hash>
</Codenesium>*/