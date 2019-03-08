using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiBadgesModelMapper
	{
		public virtual ApiBadgesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBadgesClientRequestModel request)
		{
			var response = new ApiBadgesClientResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.Name,
			                       request.UserId);
			return response;
		}

		public virtual ApiBadgesClientRequestModel MapClientResponseToRequest(
			ApiBadgesClientResponseModel response)
		{
			var request = new ApiBadgesClientRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>6c90883b6bfbc2c2fdce3c73b1bca5bd</Hash>
</Codenesium>*/