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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/