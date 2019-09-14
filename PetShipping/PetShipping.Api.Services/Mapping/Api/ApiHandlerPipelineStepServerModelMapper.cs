using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiHandlerPipelineStepServerModelMapper : IApiHandlerPipelineStepServerModelMapper
	{
		public virtual ApiHandlerPipelineStepServerResponseModel MapServerRequestToResponse(
			int id,
			ApiHandlerPipelineStepServerRequestModel request)
		{
			var response = new ApiHandlerPipelineStepServerResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiHandlerPipelineStepServerRequestModel MapServerResponseToRequest(
			ApiHandlerPipelineStepServerResponseModel response)
		{
			var request = new ApiHandlerPipelineStepServerRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public virtual ApiHandlerPipelineStepClientRequestModel MapServerResponseToClientRequest(
			ApiHandlerPipelineStepServerResponseModel response)
		{
			var request = new ApiHandlerPipelineStepClientRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel> CreatePatch(ApiHandlerPipelineStepServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel>();
			patch.Replace(x => x.HandlerId, model.HandlerId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fc169e682d6196b4d12553d41c32d860</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/