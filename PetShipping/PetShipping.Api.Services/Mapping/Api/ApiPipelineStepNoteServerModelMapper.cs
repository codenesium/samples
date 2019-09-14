using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepNoteServerModelMapper : IApiPipelineStepNoteServerModelMapper
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
    <Hash>e5c64c296d231231f86a5ad135f84de8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/