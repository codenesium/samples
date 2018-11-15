using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>b7b1b4c5ccebc0cce6cb993dc73ef274</Hash>
</Codenesium>*/