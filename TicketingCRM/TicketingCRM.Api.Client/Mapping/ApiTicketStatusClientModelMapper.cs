using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiTicketStatusModelMapper : IApiTicketStatusModelMapper
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
    <Hash>672643837e35f442fb846b8ddf35b251</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/