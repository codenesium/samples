using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiVotesServerModelMapper
	{
		public virtual ApiVotesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVotesServerRequestModel request)
		{
			var response = new ApiVotesServerResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVotesServerRequestModel MapServerResponseToRequest(
			ApiVotesServerResponseModel response)
		{
			var request = new ApiVotesServerRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public virtual ApiVotesClientRequestModel MapServerResponseToClientRequest(
			ApiVotesServerResponseModel response)
		{
			var request = new ApiVotesClientRequestModel();
			request.SetProperties(
				response.BountyAmount,
				response.CreationDate,
				response.PostId,
				response.UserId,
				response.VoteTypeId);
			return request;
		}

		public JsonPatchDocument<ApiVotesServerRequestModel> CreatePatch(ApiVotesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVotesServerRequestModel>();
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
    <Hash>ab608d3712d69e97706ee8c9a1848581</Hash>
</Codenesium>*/