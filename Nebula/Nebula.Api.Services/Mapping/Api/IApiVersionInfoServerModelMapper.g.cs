using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiVersionInfoServerModelMapper
	{
		ApiVersionInfoServerResponseModel MapServerRequestToResponse(
			long version,
			ApiVersionInfoServerRequestModel request);

		ApiVersionInfoServerRequestModel MapServerResponseToRequest(
			ApiVersionInfoServerResponseModel response);

		ApiVersionInfoClientRequestModel MapServerResponseToClientRequest(
			ApiVersionInfoServerResponseModel response);

		JsonPatchDocument<ApiVersionInfoServerRequestModel> CreatePatch(ApiVersionInfoServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>eb03f0a652e26224fd17b9ac98eb979d</Hash>
</Codenesium>*/