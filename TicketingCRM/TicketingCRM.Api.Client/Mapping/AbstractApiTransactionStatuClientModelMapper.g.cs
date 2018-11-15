using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTransactionStatuModelMapper
	{
		public virtual ApiTransactionStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionStatuClientRequestModel request)
		{
			var response = new ApiTransactionStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatuClientRequestModel MapClientResponseToRequest(
			ApiTransactionStatuClientResponseModel response)
		{
			var request = new ApiTransactionStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>371ec030d848bb7fc63ed2d42a00ce73</Hash>
</Codenesium>*/