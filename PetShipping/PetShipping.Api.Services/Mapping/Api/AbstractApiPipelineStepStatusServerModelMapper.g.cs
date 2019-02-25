using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepStatusServerModelMapper
	{
		public virtual ApiPipelineStepStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStatusServerRequestModel request)
		{
			var response = new ApiPipelineStepStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatusServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStatusServerResponseModel response)
		{
			var request = new ApiPipelineStepStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPipelineStepStatusClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStatusServerResponseModel response)
		{
			var request = new ApiPipelineStepStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStatusServerRequestModel> CreatePatch(ApiPipelineStepStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>24fd89c57b17a227c4607f01ac2e0536</Hash>
</Codenesium>*/