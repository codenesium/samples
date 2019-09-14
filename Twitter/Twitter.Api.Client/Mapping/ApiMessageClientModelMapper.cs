using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiMessageModelMapper : IApiMessageModelMapper
	{
		public virtual ApiMessageClientResponseModel MapClientRequestToResponse(
			int messageId,
			ApiMessageClientRequestModel request)
		{
			var response = new ApiMessageClientResponseModel();
			response.SetProperties(messageId,
			                       request.Content,
			                       request.SenderUserId);
			return response;
		}

		public virtual ApiMessageClientRequestModel MapClientResponseToRequest(
			ApiMessageClientResponseModel response)
		{
			var request = new ApiMessageClientRequestModel();
			request.SetProperties(
				response.Content,
				response.SenderUserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a8e482ac591a25efb5d3c60f6c2ce98f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/