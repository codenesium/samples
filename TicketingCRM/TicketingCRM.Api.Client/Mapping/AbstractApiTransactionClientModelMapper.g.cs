using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTransactionModelMapper
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
    <Hash>d7bb66b88aba498f18f0b171a0a7a1eb</Hash>
</Codenesium>*/