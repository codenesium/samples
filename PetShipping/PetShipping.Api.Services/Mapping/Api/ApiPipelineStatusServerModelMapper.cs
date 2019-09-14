using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatusServerModelMapper : IApiPipelineStatusServerModelMapper
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
    <Hash>0cb038827fbd690fec07b2b67f8e68dd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/