using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiLocationServerModelMapper
	{
		ApiLocationServerResponseModel MapServerRequestToResponse(
			short locationID,
			ApiLocationServerRequestModel request);

		ApiLocationServerRequestModel MapServerResponseToRequest(
			ApiLocationServerResponseModel response);

		ApiLocationClientRequestModel MapServerResponseToClientRequest(
			ApiLocationServerResponseModel response);

		JsonPatchDocument<ApiLocationServerRequestModel> CreatePatch(ApiLocationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>436642e16d282c65d6a3777066a8482e</Hash>
</Codenesium>*/