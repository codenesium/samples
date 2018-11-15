using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepNoteServerModelMapper
	{
		public virtual ApiPipelineStepNoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepNoteServerRequestModel request)
		{
			var response = new ApiPipelineStepNoteServerResponseModel();
			response.SetProperties(id,
			                       request.EmployeeId,
			                       request.Note,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepNoteServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepNoteServerResponseModel response)
		{
			var request = new ApiPipelineStepNoteServerRequestModel();
			request.SetProperties(
				response.EmployeeId,
				response.Note,
				response.PipelineStepId);
			return request;
		}

		public virtual ApiPipelineStepNoteClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepNoteServerResponseModel response)
		{
			var request = new ApiPipelineStepNoteClientRequestModel();
			request.SetProperties(
				response.EmployeeId,
				response.Note,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepNoteServerRequestModel> CreatePatch(ApiPipelineStepNoteServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepNoteServerRequestModel>();
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7cbedee48f3f5b6180a098517f2f99f8</Hash>
</Codenesium>*/