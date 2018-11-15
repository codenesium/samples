using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiMessageModelMapper
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
    <Hash>9637ba2a00aeadd2d75e15a985ec0746</Hash>
</Codenesium>*/