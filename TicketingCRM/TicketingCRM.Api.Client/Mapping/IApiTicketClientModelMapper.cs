using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTicketModelMapper
	{
		ApiTicketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketClientRequestModel request);

		ApiTicketClientRequestModel MapClientResponseToRequest(
			ApiTicketClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4e83177a997fa4650419c03b5e46ffb7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/