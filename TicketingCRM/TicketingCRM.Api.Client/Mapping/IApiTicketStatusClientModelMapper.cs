using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTicketStatusModelMapper
	{
		ApiTicketStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketStatusClientRequestModel request);

		ApiTicketStatusClientRequestModel MapClientResponseToRequest(
			ApiTicketStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>976627c1db2bb4a11dfb7a794b8e2f92</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/