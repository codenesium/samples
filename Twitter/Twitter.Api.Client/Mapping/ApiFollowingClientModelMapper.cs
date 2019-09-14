using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiFollowingModelMapper : IApiFollowingModelMapper
	{
		public virtual ApiFollowingClientResponseModel MapClientRequestToResponse(
			int userId,
			ApiFollowingClientRequestModel request)
		{
			var response = new ApiFollowingClientResponseModel();
			response.SetProperties(userId,
			                       request.DateFollowed,
			                       request.Muted);
			return response;
		}

		public virtual ApiFollowingClientRequestModel MapClientResponseToRequest(
			ApiFollowingClientResponseModel response)
		{
			var request = new ApiFollowingClientRequestModel();
			request.SetProperties(
				response.DateFollowed,
				response.Muted);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6baa9ae2e50b029924eb39dd965e8ade</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/