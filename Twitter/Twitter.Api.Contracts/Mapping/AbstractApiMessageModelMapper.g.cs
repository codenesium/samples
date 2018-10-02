using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiMessageModelMapper
	{
		public virtual ApiMessageResponseModel MapRequestToResponse(
			int messageId,
			ApiMessageRequestModel request)
		{
			var response = new ApiMessageResponseModel();
			response.SetProperties(messageId,
			                       request.Content,
			                       request.SenderUserId);
			return response;
		}

		public virtual ApiMessageRequestModel MapResponseToRequest(
			ApiMessageResponseModel response)
		{
			var request = new ApiMessageRequestModel();
			request.SetProperties(
				response.Content,
				response.SenderUserId);
			return request;
		}

		public JsonPatchDocument<ApiMessageRequestModel> CreatePatch(ApiMessageRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMessageRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.SenderUserId, model.SenderUserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b665be2f44de7b0575c934cc724f956f</Hash>
</Codenesium>*/