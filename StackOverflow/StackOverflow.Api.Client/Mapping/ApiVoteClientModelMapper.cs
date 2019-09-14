using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiVoteModelMapper : IApiVoteModelMapper
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
    <Hash>fd9dc746a481818aedf831321f648da0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/