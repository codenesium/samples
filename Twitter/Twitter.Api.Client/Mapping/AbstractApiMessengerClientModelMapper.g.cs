using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiMessengerModelMapper
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
    <Hash>6fb3e4382cb63278eb1613d448dff4b5</Hash>
</Codenesium>*/