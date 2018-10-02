using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiReplyModelMapper
	{
		public virtual ApiReplyResponseModel MapRequestToResponse(
			int replyId,
			ApiReplyRequestModel request)
		{
			var response = new ApiReplyResponseModel();
			response.SetProperties(replyId,
			                       request.Content,
			                       request.Date,
			                       request.ReplierUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiReplyRequestModel MapResponseToRequest(
			ApiReplyResponseModel response)
		{
			var request = new ApiReplyRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.ReplierUserId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiReplyRequestModel> CreatePatch(ApiReplyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiReplyRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.ReplierUserId, model.ReplierUserId);
			patch.Replace(x => x.Time, model.Time);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>db11bf27a4627889e0e14c06ee9520fc</Hash>
</Codenesium>*/