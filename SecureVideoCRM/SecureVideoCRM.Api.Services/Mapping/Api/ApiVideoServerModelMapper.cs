using Microsoft.AspNetCore.JsonPatch;
using SecureVideoCRMNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiVideoServerModelMapper : IApiVideoServerModelMapper
	{
		public virtual ApiVideoServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVideoServerRequestModel request)
		{
			var response = new ApiVideoServerResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Title,
			                       request.Url);
			return response;
		}

		public virtual ApiVideoServerRequestModel MapServerResponseToRequest(
			ApiVideoServerResponseModel response)
		{
			var request = new ApiVideoServerRequestModel();
			request.SetProperties(
				response.Description,
				response.Title,
				response.Url);
			return request;
		}

		public virtual ApiVideoClientRequestModel MapServerResponseToClientRequest(
			ApiVideoServerResponseModel response)
		{
			var request = new ApiVideoClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Title,
				response.Url);
			return request;
		}

		public JsonPatchDocument<ApiVideoServerRequestModel> CreatePatch(ApiVideoServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVideoServerRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Title, model.Title);
			patch.Replace(x => x.Url, model.Url);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>31b5145055a6c6c1dc9a85cc29b9c6ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/