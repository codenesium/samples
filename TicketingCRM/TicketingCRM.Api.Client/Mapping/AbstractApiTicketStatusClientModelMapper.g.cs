using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTicketStatusModelMapper
	{
		public virtual ApiTicketStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketStatusClientRequestModel request)
		{
			var response = new ApiTicketStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatusClientRequestModel MapClientResponseToRequest(
			ApiTicketStatusClientResponseModel response)
		{
			var request = new ApiTicketStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7b80dbd4ef2bff880d3c4de9b5f5bbec</Hash>
</Codenesium>*/