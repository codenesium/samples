using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiTicketModelMapper : IApiTicketModelMapper
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
    <Hash>e12a5d98f6784cb48a41f208e0267f40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/