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
			                       request.RwType);
			return response;
		}

		public virtual ApiPostHistoryTypeServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiPostHistoryTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypeServerResponseModel response)
		{
			var request = new ApiPostHistoryTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> CreatePatch(ApiPostHistoryTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryTypeServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1e72501c3e89d3aa8676fb17b993bea7</Hash>
</Codenesium>*/