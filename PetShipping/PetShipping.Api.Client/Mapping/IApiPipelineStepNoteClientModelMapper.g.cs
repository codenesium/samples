using PetShippingNS.Api.Contracts;
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
    <Hash>0b9f45ea305e102d0d3423c9b25e6cdc</Hash>
</Codenesium>*/