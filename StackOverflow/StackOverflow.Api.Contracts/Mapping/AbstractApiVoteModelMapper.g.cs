using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiVoteModelMapper
	{
		public virtual ApiVoteResponseModel MapRequestToResponse(
			int id,
			ApiVoteRequestModel request)
		{
			var response = new ApiVoteResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVoteRequestModel MapResponseToRequest(
			ApiVoteResponseModel response)
		{
			var request = new ApiVoteRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public JsonPatchDocument<ApiVoteRequestModel> CreatePatch(ApiVoteRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteRequestModel>();
			patch.Replace(x => x.BountyAmount, model.BountyAmount);
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.UserId, model.UserId);
			patch.Replace(x => x.VoteTypeId, model.VoteTypeId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d721ff35683855ebacc25a7c9607d1ab</Hash>
</Codenesium>*/