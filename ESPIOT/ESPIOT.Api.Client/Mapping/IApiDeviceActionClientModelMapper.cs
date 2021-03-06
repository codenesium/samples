using ESPIOTNS.Api.Contracts;
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
    <Hash>78dd9edbb137c2821be8e4b4a1cba027</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/