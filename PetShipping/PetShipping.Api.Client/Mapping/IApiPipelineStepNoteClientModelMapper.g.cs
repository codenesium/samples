using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepNoteModelMapper
	{
		ApiPipelineStepNoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepNoteClientRequestModel request);

		ApiPipelineStepNoteClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepNoteClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d5f800805ae45565d9908c6e73fe576f</Hash>
</Codenesium>*/