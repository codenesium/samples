using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiVoteServerModelMapper
	{
		public virtual ApiVoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteServerRequestModel request)
		{
			var response = new ApiVoteServerResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVoteServerRequestModel MapServerResponseToRequest(
			ApiVoteServerResponseModel response)
		{
			var request = new ApiVoteServerRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public virtual ApiVoteClientRequestModel MapServerResponseToClientRequest(
			ApiVoteServerResponseModel response)
		{
			var request = new ApiVoteClientRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public JsonPatchDocument<ApiVoteServerRequestModel> CreatePatch(ApiVoteServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteServerRequestModel>();
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
    <Hash>1b8feed4b3fb2621188ddbdbbcd1323b</Hash>
</Codenesium>*/