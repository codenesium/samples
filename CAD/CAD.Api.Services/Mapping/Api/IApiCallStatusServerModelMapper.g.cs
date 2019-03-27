using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallStatusServerModelMapper
	{
		ApiCallStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallStatusServerRequestModel request);

		ApiCallStatusServerRequestModel MapServerResponseToRequest(
			ApiCallStatusServerResponseModel response);

		ApiCallStatusClientRequestModel MapServerResponseToClientRequest(
			ApiCallStatusServerResponseModel response);

		JsonPatchDocument<ApiCallStatusServerRequestModel> CreatePatch(ApiCallStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5fdf3195b562b8208faf3263f5b15220</Hash>
</Codenesium>*/