using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiUserServerModelMapper : IApiUserServerModelMapper
	{
		public virtual ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request)
		{
			var response = new ApiUserServerResponseModel();
			response.SetProperties(id,
			                       request.Password,
			                       request.Username);
			return response;
		}

		public virtual ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserServerRequestModel();
			request.SetProperties(
				response.Password,
				response.Username);
			return request;
		}

		public virtual ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Password,
				response.Username);
			return request;
		}

		public JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserServerRequestModel>();
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.Username, model.Username);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f9b16abc15a0b7bece33df6e8194947a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/