using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelServerModelMapper
	{
		ApiProductModelServerResponseModel MapServerRequestToResponse(
			int productModelID,
			ApiProductModelServerRequestModel request);

		ApiProductModelServerRequestModel MapServerResponseToRequest(
			ApiProductModelServerResponseModel response);

		ApiProductModelClientRequestModel MapServerResponseToClientRequest(
			ApiProductModelServerResponseModel response);

		JsonPatchDocument<ApiProductModelServerRequestModel> CreatePatch(ApiProductModelServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>358e126c8a1136bd10dc227810763d8b</Hash>
</Codenesium>*/