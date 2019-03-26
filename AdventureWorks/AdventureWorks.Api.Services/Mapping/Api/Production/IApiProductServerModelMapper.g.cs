using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductServerModelMapper
	{
		ApiProductServerResponseModel MapServerRequestToResponse(
			int productID,
			ApiProductServerRequestModel request);

		ApiProductServerRequestModel MapServerResponseToRequest(
			ApiProductServerResponseModel response);

		ApiProductClientRequestModel MapServerResponseToClientRequest(
			ApiProductServerResponseModel response);

		JsonPatchDocument<ApiProductServerRequestModel> CreatePatch(ApiProductServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4f6e2ada0c9d952379cd038c6bbee81e</Hash>
</Codenesium>*/