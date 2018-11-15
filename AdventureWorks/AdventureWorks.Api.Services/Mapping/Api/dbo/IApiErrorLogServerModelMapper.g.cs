using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiErrorLogServerModelMapper
	{
		ApiErrorLogServerResponseModel MapServerRequestToResponse(
			int errorLogID,
			ApiErrorLogServerRequestModel request);

		ApiErrorLogServerRequestModel MapServerResponseToRequest(
			ApiErrorLogServerResponseModel response);

		ApiErrorLogClientRequestModel MapServerResponseToClientRequest(
			ApiErrorLogServerResponseModel response);

		JsonPatchDocument<ApiErrorLogServerRequestModel> CreatePatch(ApiErrorLogServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>80b1dfdc7ca206a256a77f94555e2e03</Hash>
</Codenesium>*/