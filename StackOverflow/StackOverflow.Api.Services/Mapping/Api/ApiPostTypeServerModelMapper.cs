using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostTypeServerModelMapper : IApiPostTypeServerModelMapper
	{
		public virtual ApiPostTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostTypeServerRequestModel request)
		{
			var response = new ApiPostTypeServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostTypeServerRequestModel MapServerResponseToRequest(
			ApiPostTypeServerResponseModel response)
		{
			var request = new ApiPostTypeServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiPostTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostTypeServerResponseModel response)
		{
			var request = new ApiPostTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiPostTypeServerRequestModel> CreatePatch(ApiPostTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostTypeServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>aa08a9575d58cdc70da8e3ac3890e5ae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/