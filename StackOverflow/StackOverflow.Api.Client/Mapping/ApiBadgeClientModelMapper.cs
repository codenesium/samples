using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiBadgeModelMapper : IApiBadgeModelMapper
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
    <Hash>e741c1e2caacaa73e2fc8f3723507b6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/