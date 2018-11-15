using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTicketModelMapper
	{
		public virtual ApiTicketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketClientRequestModel request)
		{
			var response = new ApiTicketClientResponseModel();
			response.SetProperties(id,
			                       request.PublicId,
			                       request.TicketStatusId);
			return response;
		}

		public virtual ApiTicketClientRequestModel MapClientResponseToRequest(
			ApiTicketClientResponseModel response)
		{
			var request = new ApiTicketClientRequestModel();
			request.SetProperties(
				response.PublicId,
				response.TicketStatusId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a5a07b7d409c337150bc94c3feb264ec</Hash>
</Codenesium>*/