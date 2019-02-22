using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallServerModelMapper
	{
		ApiCallServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallServerRequestModel request);

		ApiCallServerRequestModel MapServerResponseToRequest(
			ApiCallServerResponseModel response);

		ApiCallClientRequestModel MapServerResponseToClientRequest(
			ApiCallServerResponseModel response);

		JsonPatchDocument<ApiCallServerRequestModel> CreatePatch(ApiCallServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c4fff7b4cd13184e7f06736d3a02233b</Hash>
</Codenesium>*/