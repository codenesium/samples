using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiMessageServerModelMapper
	{
		public virtual ApiMessageServerResponseModel MapServerRequestToResponse(
			int messageId,
			ApiMessageServerRequestModel request)
		{
			var response = new ApiMessageServerResponseModel();
			response.SetProperties(messageId,
			                       request.Content,
			                       request.SenderUserId);
			return response;
		}

		public virtual ApiMessageServerRequestModel MapServerResponseToRequest(
			ApiMessageServerResponseModel response)
		{
			var request = new ApiMessageServerRequestModel();
			request.SetProperties(
				response.Content,
				response.SenderUserId);
			return request;
		}

		public virtual ApiMessageClientRequestModel MapServerResponseToClientRequest(
			ApiMessageServerResponseModel response)
		{
			var request = new ApiMessageClientRequestModel();
			request.SetProperties(
				response.Content,
				response.SenderUserId);
			return request;
		}

		public JsonPatchDocument<ApiMessageServerRequestModel> CreatePatch(ApiMessageServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMessageServerRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.SenderUserId, model.SenderUserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7065bca75015115910ea6248b7de68ce</Hash>
</Codenesium>*/