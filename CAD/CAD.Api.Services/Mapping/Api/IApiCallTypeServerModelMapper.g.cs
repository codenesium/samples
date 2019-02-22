using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallTypeServerModelMapper
	{
		ApiCallTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallTypeServerRequestModel request);

		ApiCallTypeServerRequestModel MapServerResponseToRequest(
			ApiCallTypeServerResponseModel response);

		ApiCallTypeClientRequestModel MapServerResponseToClientRequest(
			ApiCallTypeServerResponseModel response);

		JsonPatchDocument<ApiCallTypeServerRequestModel> CreatePatch(ApiCallTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d98bb1168d12acfeee785b285bce7e9e</Hash>
</Codenesium>*/