using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTicketStatuModelMapper
	{
		public virtual ApiTicketStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketStatuClientRequestModel request)
		{
			var response = new ApiTicketStatuClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatuClientRequestModel MapClientResponseToRequest(
			ApiTicketStatuClientResponseModel response)
		{
			var request = new ApiTicketStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b21cc43f1daba9e06ccd16a53024c2e5</Hash>
</Codenesium>*/