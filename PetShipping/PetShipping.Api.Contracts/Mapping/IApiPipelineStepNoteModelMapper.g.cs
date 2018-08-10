using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStepNoteModelMapper
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
    <Hash>5299e8e69abffece50d906a926c87289</Hash>
</Codenesium>*/