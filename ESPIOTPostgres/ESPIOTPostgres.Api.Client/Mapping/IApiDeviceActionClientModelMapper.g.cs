using ESPIOTPostgresNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Client
{
	public partial interface IApiDeviceActionModelMapper
	{
		ApiDeviceActionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceActionClientRequestModel request);

		ApiDeviceActionClientRequestModel MapClientResponseToRequest(
			ApiDeviceActionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5d7f62972625fde723617492fe860871</Hash>
</Codenesium>*/