using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiTransactionStatusModelMapper : IApiTransactionStatusModelMapper
	{
		public virtual ApiTransactionStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionStatusClientRequestModel request)
		{
			var response = new ApiTransactionStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatusClientRequestModel MapClientResponseToRequest(
			ApiTransactionStatusClientResponseModel response)
		{
			var request = new ApiTransactionStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cda6ce1c49804c1347780da31c088f9e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/