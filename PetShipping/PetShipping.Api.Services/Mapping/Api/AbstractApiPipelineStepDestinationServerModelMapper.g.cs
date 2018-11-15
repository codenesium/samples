using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepDestinationServerModelMapper
	{
		public virtual ApiPipelineStepDestinationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepDestinationServerRequestModel request)
		{
			var response = new ApiPipelineStepDestinationServerResponseModel();
			response.SetProperties(id,
			                       request.DestinationId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepDestinationServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepDestinationServerResponseModel response)
		{
			var request = new ApiPipelineStepDestinationServerRequestModel();
			request.SetProperties(
				response.DestinationId,
				response.PipelineStepId);
			return request;
		}

		public virtual ApiPipelineStepDestinationClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepDestinationServerResponseModel response)
		{
			var request = new ApiPipelineStepDestinationClientRequestModel();
			request.SetProperties(
				response.DestinationId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepDestinationServerRequestModel> CreatePatch(ApiPipelineStepDestinationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepDestinationServerRequestModel>();
			patch.Replace(x => x.DestinationId, model.DestinationId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a3df79e299f46c14e19219798105480f</Hash>
</Codenesium>*/