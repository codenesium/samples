using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTransactionModelMapper
	{
		ApiTransactionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionClientRequestModel request);

		ApiTransactionClientRequestModel MapClientResponseToRequest(
			ApiTransactionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>575a958eaeb02cebbc183c6249b4f55b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/