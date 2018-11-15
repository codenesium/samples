using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepStatuServerModelMapper
	{
		public virtual ApiPipelineStepStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStatuServerRequestModel request)
		{
			var response = new ApiPipelineStepStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatuServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStatuServerResponseModel response)
		{
			var request = new ApiPipelineStepStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPipelineStepStatuClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStatuServerResponseModel response)
		{
			var request = new ApiPipelineStepStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStatuServerRequestModel> CreatePatch(ApiPipelineStepStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7db99c6128fad41e4367985b2093deae</Hash>
</Codenesium>*/