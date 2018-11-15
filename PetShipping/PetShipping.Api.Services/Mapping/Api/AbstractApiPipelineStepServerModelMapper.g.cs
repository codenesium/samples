using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepServerModelMapper
	{
		public virtual ApiPipelineStepServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepServerRequestModel request)
		{
			var response = new ApiPipelineStepServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PipelineStepStatusId,
			                       request.ShipperId);
			return response;
		}

		public virtual ApiPipelineStepServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepServerResponseModel response)
		{
			var request = new ApiPipelineStepServerRequestModel();
			request.SetProperties(
				response.Name,
				response.PipelineStepStatusId,
				response.ShipperId);
			return request;
		}

		public virtual ApiPipelineStepClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepServerResponseModel response)
		{
			var request = new ApiPipelineStepClientRequestModel();
			request.SetProperties(
				response.Name,
				response.PipelineStepStatusId,
				response.ShipperId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepServerRequestModel> CreatePatch(ApiPipelineStepServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PipelineStepStatusId, model.PipelineStepStatusId);
			patch.Replace(x => x.ShipperId, model.ShipperId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>423920191e42d62c3206dbc6d1c366eb</Hash>
</Codenesium>*/