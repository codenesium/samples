using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiVotesModelMapper
	{
		public virtual ApiVotesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVotesClientRequestModel request)
		{
			var response = new ApiVotesClientResponseModel();
			response.SetProperties(id,
			                       request.BountyAmount,
			                       request.CreationDate,
			                       request.PostId,
			                       request.UserId,
			                       request.VoteTypeId);
			return response;
		}

		public virtual ApiVotesClientRequestModel MapClientResponseToRequest(
			ApiVotesClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>0e118f44ff898fa692dc2431bb97dbff</Hash>
</Codenesium>*/