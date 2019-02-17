using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiTransactionStatusModelMapper
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
    <Hash>d1bc24055c68001030f20b0c4ae1aece</Hash>
</Codenesium>*/