using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStatusServerModelMapper
	{
		public virtual ApiPipelineStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStatusServerRequestModel request)
		{
			var response = new ApiPipelineStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatusServerRequestModel MapServerResponseToRequest(
			ApiPipelineStatusServerResponseModel response)
		{
			var request = new ApiPipelineStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPipelineStatusClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStatusServerResponseModel response)
		{
			var request = new ApiPipelineStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStatusServerRequestModel> CreatePatch(ApiPipelineStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c30e0c5774b12b63c17c4eb536734835</Hash>
</Codenesium>*/