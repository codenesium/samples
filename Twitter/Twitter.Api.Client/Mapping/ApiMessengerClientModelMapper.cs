using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiMessengerModelMapper : IApiMessengerModelMapper
	{
		public virtual ApiMessengerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMessengerClientRequestModel request)
		{
			var response = new ApiMessengerClientResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.FromUserId,
			                       request.MessageId,
			                       request.Time,
			                       request.ToUserId,
			                       request.UserId);
			return response;
		}

		public virtual ApiMessengerClientRequestModel MapClientResponseToRequest(
			ApiMessengerClientResponseModel response)
		{
			var request = new ApiMessengerClientRequestModel();
			request.SetProperties(
				response.Date,
				response.FromUserId,
				response.MessageId,
				response.Time,
				response.ToUserId,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>839b2bf522a3ed05eefdea3f3c5d8331</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/