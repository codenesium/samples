using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiVoteTypesModelMapper
	{
		public virtual ApiVoteTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteTypesClientRequestModel request)
		{
			var response = new ApiVoteTypesClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypesClientRequestModel MapClientResponseToRequest(
			ApiVoteTypesClientResponseModel response)
		{
			var request = new ApiVoteTypesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>82a1224404d8e8c9ae5f509224665c43</Hash>
</Codenesium>*/