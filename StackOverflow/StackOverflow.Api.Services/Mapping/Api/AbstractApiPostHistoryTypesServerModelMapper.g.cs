using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostHistoryTypesServerModelMapper
	{
		public virtual ApiPostHistoryTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryTypesServerRequestModel request)
		{
			var response = new ApiPostHistoryTypesServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostHistoryTypesServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypesServerResponseModel response)
		{
			var request = new ApiPostHistoryTypesServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiPostHistoryTypesClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypesServerResponseModel response)
		{
			var request = new ApiPostHistoryTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryTypesServerRequestModel> CreatePatch(ApiPostHistoryTypesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryTypesServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>eefb32e591ea6ec54a0882325400a7ae</Hash>
</Codenesium>*/