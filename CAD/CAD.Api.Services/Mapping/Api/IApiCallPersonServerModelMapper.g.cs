using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallPersonServerModelMapper
	{
		ApiCallPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallPersonServerRequestModel request);

		ApiCallPersonServerRequestModel MapServerResponseToRequest(
			ApiCallPersonServerResponseModel response);

		ApiCallPersonClientRequestModel MapServerResponseToClientRequest(
			ApiCallPersonServerResponseModel response);

		JsonPatchDocument<ApiCallPersonServerRequestModel> CreatePatch(ApiCallPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>07d49cfcc8263d42ea51209b7caa9e33</Hash>
</Codenesium>*/