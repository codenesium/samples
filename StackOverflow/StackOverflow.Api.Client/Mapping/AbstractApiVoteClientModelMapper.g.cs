using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiVoteModelMapper
	{
		public virtual ApiVoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteClientRequestModel request)
		{
			var response = new ApiVoteClientResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVoteClientRequestModel MapClientResponseToRequest(
			ApiVoteClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>d087a34084768e45085c977ceadd5aca</Hash>
</Codenesium>*/