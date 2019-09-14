using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiVoteTypeModelMapper : IApiVoteTypeModelMapper
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
    <Hash>fb891f4559b8f3abac3dfa3b03c99bff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/