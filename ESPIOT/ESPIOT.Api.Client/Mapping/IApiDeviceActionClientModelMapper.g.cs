using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
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
    <Hash>db72e740030d0612072244b2b8052255</Hash>
</Codenesium>*/