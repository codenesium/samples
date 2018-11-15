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
			                       request.Type);
			return response;
		}

		public virtual ApiLinkTypeServerRequestModel MapServerResponseToRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeServerRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public virtual ApiLinkTypeClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypeServerResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiLinkTypeServerRequestModel> CreatePatch(ApiLinkTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkTypeServerRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8f641af09de0728c2948748be42dbdb0</Hash>
</Codenesium>*/