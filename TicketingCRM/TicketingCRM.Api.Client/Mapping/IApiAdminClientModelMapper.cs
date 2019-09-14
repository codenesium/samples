using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiAdminModelMapper
	{
		ApiAdminClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAdminClientRequestModel request);

		ApiAdminClientRequestModel MapClientResponseToRequest(
			ApiAdminClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a3dcf618047efeb7ad7d116f0cb0e075</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/