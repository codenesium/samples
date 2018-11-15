using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostHistoryTypeServerModelMapper
	{
		public virtual ApiPostHistoryTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryTypeServerRequestModel request)
		{
			var response = new ApiPostHistoryTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostHistoryTypeServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeServerRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public virtual ApiPostHistoryTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> CreatePatch(ApiPostHistoryTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryTypeServerRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e64b423b78f0271fcc99eddd1e6967e9</Hash>
</Codenesium>*/