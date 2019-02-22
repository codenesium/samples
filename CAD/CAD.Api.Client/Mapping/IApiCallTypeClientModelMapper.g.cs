using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallTypeModelMapper
	{
		ApiCallTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallTypeClientRequestModel request);

		ApiCallTypeClientRequestModel MapClientResponseToRequest(
			ApiCallTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>41339673a90572c3e8eaa962017dacc8</Hash>
</Codenesium>*/