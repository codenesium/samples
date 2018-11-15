using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiVPersonServerModelMapper
	{
		ApiVPersonServerResponseModel MapServerRequestToResponse(
			int personId,
			ApiVPersonServerRequestModel request);

		ApiVPersonServerRequestModel MapServerResponseToRequest(
			ApiVPersonServerResponseModel response);

		ApiVPersonClientRequestModel MapServerResponseToClientRequest(
			ApiVPersonServerResponseModel response);

		JsonPatchDocument<ApiVPersonServerRequestModel> CreatePatch(ApiVPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cdd9bbe8d4f538e2786e42b95e8d8a32</Hash>
</Codenesium>*/