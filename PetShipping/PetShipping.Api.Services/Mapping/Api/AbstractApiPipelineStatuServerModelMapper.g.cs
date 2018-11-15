using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStatuServerModelMapper
	{
		public virtual ApiPipelineStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStatuServerRequestModel request)
		{
			var response = new ApiPipelineStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatuServerRequestModel MapServerResponseToRequest(
			ApiPipelineStatuServerResponseModel response)
		{
			var request = new ApiPipelineStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPipelineStatuClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStatuServerResponseModel response)
		{
			var request = new ApiPipelineStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStatuServerRequestModel> CreatePatch(ApiPipelineStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1f976fd89045df8e0dfb6ecb5a2e0d81</Hash>
</Codenesium>*/