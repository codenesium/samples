using ESPIOTPostgresNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Client
{
	public partial interface IApiDeviceModelMapper
	{
		ApiDeviceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceClientRequestModel request);

		ApiDeviceClientRequestModel MapClientResponseToRequest(
			ApiDeviceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2a0d1a841f6f51937ade5210bc79a54d</Hash>
</Codenesium>*/