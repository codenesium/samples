using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiFollowingModelMapper
	{
		public virtual ApiFollowingResponseModel MapRequestToResponse(
			string userId,
			ApiFollowingRequestModel request)
		{
			var response = new ApiFollowingResponseModel();
			response.SetProperties(userId,
			                       request.DateFollowed,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowingRequestModel MapResponseToRequest(
			ApiFollowingResponseModel response)
		{
			var request = new ApiFollowingRequestModel();
			request.SetProperties(
				response.DateFollowed,
				response.Muted);
			return request;
		}

		public JsonPatchDocument<ApiFollowingRequestModel> CreatePatch(ApiFollowingRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFollowingRequestModel>();
			patch.Replace(x => x.DateFollowed, model.DateFollowed);
			patch.Replace(x => x.Muted, model.Muted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7d336e5157a7e7e1a07e8ff63ef59218</Hash>
</Codenesium>*/