using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinksServerModelMapper
	{
		ApiPostLinksServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostLinksServerRequestModel request);

		ApiPostLinksServerRequestModel MapServerResponseToRequest(
			ApiPostLinksServerResponseModel response);

		ApiPostLinksClientRequestModel MapServerResponseToClientRequest(
			ApiPostLinksServerResponseModel response);

		JsonPatchDocument<ApiPostLinksServerRequestModel> CreatePatch(ApiPostLinksServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fd026cdebf48c52392190a273a02f2a5</Hash>
</Codenesium>*/