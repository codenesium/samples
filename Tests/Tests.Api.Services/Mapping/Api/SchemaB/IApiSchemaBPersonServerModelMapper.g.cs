using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaBPersonServerModelMapper
	{
		ApiSchemaBPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSchemaBPersonServerRequestModel request);

		ApiSchemaBPersonServerRequestModel MapServerResponseToRequest(
			ApiSchemaBPersonServerResponseModel response);

		ApiSchemaBPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSchemaBPersonServerResponseModel response);

		JsonPatchDocument<ApiSchemaBPersonServerRequestModel> CreatePatch(ApiSchemaBPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b9de88e857b453cfac6d471248d45c2f</Hash>
</Codenesium>*/