using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiProvinceModelMapper
	{
		ApiProvinceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiProvinceClientRequestModel request);

		ApiProvinceClientRequestModel MapClientResponseToRequest(
			ApiProvinceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>87fcc39ff2031dbe2c916c530c596e2f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/