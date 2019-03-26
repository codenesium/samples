using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPasswordServerModelMapper
	{
		ApiPasswordServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiPasswordServerRequestModel request);

		ApiPasswordServerRequestModel MapServerResponseToRequest(
			ApiPasswordServerResponseModel response);

		ApiPasswordClientRequestModel MapServerResponseToClientRequest(
			ApiPasswordServerResponseModel response);

		JsonPatchDocument<ApiPasswordServerRequestModel> CreatePatch(ApiPasswordServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7cc3e5aaa36eab20b70c98681ae8e647</Hash>
</Codenesium>*/