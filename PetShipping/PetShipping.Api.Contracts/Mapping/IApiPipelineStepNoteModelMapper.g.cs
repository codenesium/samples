using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStepNoteModelMapper
	{
		ApiPipelineStepNoteResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepNoteRequestModel request);

		ApiPipelineStepNoteRequestModel MapResponseToRequest(
			ApiPipelineStepNoteResponseModel response);

		JsonPatchDocument<ApiPipelineStepNoteRequestModel> CreatePatch(ApiPipelineStepNoteRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8217116176b78b496252751271c8fa9e</Hash>
</Codenesium>*/