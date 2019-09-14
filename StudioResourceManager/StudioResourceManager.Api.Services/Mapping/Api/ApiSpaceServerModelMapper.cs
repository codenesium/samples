using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceServerModelMapper : IApiSpaceServerModelMapper
	{
		public virtual ApiSpaceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceServerRequestModel request)
		{
			var response = new ApiSpaceServerResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceServerRequestModel MapServerResponseToRequest(
			ApiSpaceServerResponseModel response)
		{
			var request = new ApiSpaceServerRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}

		public virtual ApiSpaceClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceServerResponseModel response)
		{
			var request = new ApiSpaceClientRequestModel();
			request.SetProperties(
				response.Description,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceServerRequestModel> CreatePatch(ApiSpaceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceServerRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f7b7a2fb4d5a36d0bb25f29eb6035ed7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/