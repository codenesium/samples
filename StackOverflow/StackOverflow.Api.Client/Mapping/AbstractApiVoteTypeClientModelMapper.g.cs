using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiVoteTypeModelMapper
	{
		public virtual ApiVoteTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteTypeClientRequestModel request)
		{
			var response = new ApiVoteTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypeClientRequestModel MapClientResponseToRequest(
			ApiVoteTypeClientResponseModel response)
		{
			var request = new ApiVoteTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a8d641aa43db34e56f01cb61190be063</Hash>
</Codenesium>*/