using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallDispositionServerModelMapper
	{
		ApiCallDispositionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallDispositionServerRequestModel request);

		ApiCallDispositionServerRequestModel MapServerResponseToRequest(
			ApiCallDispositionServerResponseModel response);

		ApiCallDispositionClientRequestModel MapServerResponseToClientRequest(
			ApiCallDispositionServerResponseModel response);

		JsonPatchDocument<ApiCallDispositionServerRequestModel> CreatePatch(ApiCallDispositionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a10e5f2b6e62c274f8cf54e794cf9044</Hash>
</Codenesium>*/