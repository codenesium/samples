using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallStatuServerModelMapper
	{
		ApiCallStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallStatuServerRequestModel request);

		ApiCallStatuServerRequestModel MapServerResponseToRequest(
			ApiCallStatuServerResponseModel response);

		ApiCallStatuClientRequestModel MapServerResponseToClientRequest(
			ApiCallStatuServerResponseModel response);

		JsonPatchDocument<ApiCallStatuServerRequestModel> CreatePatch(ApiCallStatuServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>303010c786a9e34e9740061173068ba1</Hash>
</Codenesium>*/