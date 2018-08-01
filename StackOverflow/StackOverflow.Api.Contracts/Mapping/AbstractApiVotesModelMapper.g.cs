using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiVotesModelMapper
	{
		public virtual ApiVotesResponseModel MapRequestToResponse(
			int id,
			ApiVotesRequestModel request)
		{
			var response = new ApiVotesResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVotesRequestModel MapResponseToRequest(
			ApiVotesResponseModel response)
		{
			var request = new ApiVotesRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public JsonPatchDocument<ApiVotesRequestModel> CreatePatch(ApiVotesRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVotesRequestModel>();
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
    <Hash>5ca5963985eab5264324edd322946f4b</Hash>
</Codenesium>*/