using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiBadgeModelMapper
	{
		public virtual ApiBadgeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBadgeClientRequestModel request)
		{
			var response = new ApiBadgeClientResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.Name,
			                       request.UserId);
			return response;
		}

		public virtual ApiBadgeClientRequestModel MapClientResponseToRequest(
			ApiBadgeClientResponseModel response)
		{
			var request = new ApiBadgeClientRequestModel();
			request.SetProperties(
				response.Date,
				response.Name,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>128a828b96a8c0f24d167916cf2813a1</Hash>
</Codenesium>*/