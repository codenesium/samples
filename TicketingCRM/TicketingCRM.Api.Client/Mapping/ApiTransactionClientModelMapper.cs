using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiTransactionModelMapper : IApiTransactionModelMapper
	{
		public virtual ApiTransactionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionClientRequestModel request)
		{
			var response = new ApiTransactionClientResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.GatewayConfirmationNumber,
			                       request.TransactionStatusId);
			return response;
		}

		public virtual ApiTransactionClientRequestModel MapClientResponseToRequest(
			ApiTransactionClientResponseModel response)
		{
			var request = new ApiTransactionClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.GatewayConfirmationNumber,
				response.TransactionStatusId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a3e349870b1808b5e580ca4e1f46cf08</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/