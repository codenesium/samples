using ESPIOTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
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
    <Hash>de8f62a9b83a484157f4ac13bbca9aa7</Hash>
</Codenesium>*/