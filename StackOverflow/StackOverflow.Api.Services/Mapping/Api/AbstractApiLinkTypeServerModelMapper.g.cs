using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiLinkTypeServerModelMapper
	{
		public virtual ApiLinkTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkTypeServerRequestModel request)
		{
			var response = new ApiLinkTypeServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypeServerRequestModel MapServerResponseToRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiLinkTypeClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiLinkTypeServerRequestModel> CreatePatch(ApiLinkTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkTypeServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>06dcea58041128a80f8d3ff9c1fdc3c3</Hash>
</Codenesium>*/