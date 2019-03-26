using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostTypeServerModelMapper
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
    <Hash>1af940a08dde40e607b0c550ea7ff5d9</Hash>
</Codenesium>*/