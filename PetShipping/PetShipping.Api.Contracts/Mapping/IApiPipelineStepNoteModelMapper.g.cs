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
    <Hash>f6d87686836cd2b9871b7639c85eb577</Hash>
</Codenesium>*/