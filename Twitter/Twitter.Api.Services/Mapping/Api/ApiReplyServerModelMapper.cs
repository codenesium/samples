using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiReplyServerModelMapper : IApiReplyServerModelMapper
	{
		public virtual ApiReplyServerResponseModel MapServerRequestToResponse(
			int replyId,
			ApiReplyServerRequestModel request)
		{
			var response = new ApiReplyServerResponseModel();
			response.SetProperties(replyId,
			                       request.Content,
			                       request.Date,
			                       request.ReplierUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiReplyServerRequestModel MapServerResponseToRequest(
			ApiReplyServerResponseModel response)
		{
			var request = new ApiReplyServerRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.ReplierUserId,
				response.Time);
			return request;
		}

		public virtual ApiReplyClientRequestModel MapServerResponseToClientRequest(
			ApiReplyServerResponseModel response)
		{
			var request = new ApiReplyClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.ReplierUserId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiReplyServerRequestModel> CreatePatch(ApiReplyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiReplyServerRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.ReplierUserId, model.ReplierUserId);
			patch.Replace(x => x.Time, model.Time);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f000ae4a1c232eedb25a907ad39d48a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/