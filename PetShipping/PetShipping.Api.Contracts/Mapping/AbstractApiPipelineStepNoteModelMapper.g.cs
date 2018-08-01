using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepNoteModelMapper
	{
		public virtual ApiPipelineStepNoteResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepNoteRequestModel request)
		{
			var response = new ApiPipelineStepNoteResponseModel();
			response.SetProperties(id,
			                       request.EmployeeId,
			                       request.Note,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepNoteRequestModel MapResponseToRequest(
			ApiPipelineStepNoteResponseModel response)
		{
			var request = new ApiPipelineStepNoteRequestModel();
			request.SetProperties(
				response.EmployeeId,
				response.Note,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepNoteRequestModel> CreatePatch(ApiPipelineStepNoteRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepNoteRequestModel>();
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9789b6908fb88ad65d1d793d6c5921d4</Hash>
</Codenesium>*/