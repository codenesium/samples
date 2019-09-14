using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepNoteServerModelMapper
	{
		ApiPipelineStepNoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepNoteServerRequestModel request);

		ApiPipelineStepNoteServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepNoteServerResponseModel response);

		ApiPipelineStepNoteClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepNoteServerResponseModel response);

		JsonPatchDocument<ApiPipelineStepNoteServerRequestModel> CreatePatch(ApiPipelineStepNoteServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c1e397c780b77cedc3d2d3b0420665ee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/