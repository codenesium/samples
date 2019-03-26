using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShipMethodServerModelMapper
	{
		ApiShipMethodServerResponseModel MapServerRequestToResponse(
			int shipMethodID,
			ApiShipMethodServerRequestModel request);

		ApiShipMethodServerRequestModel MapServerResponseToRequest(
			ApiShipMethodServerResponseModel response);

		ApiShipMethodClientRequestModel MapServerResponseToClientRequest(
			ApiShipMethodServerResponseModel response);

		JsonPatchDocument<ApiShipMethodServerRequestModel> CreatePatch(ApiShipMethodServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d15e201f1b7e045cd2cdfc467aa8999e</Hash>
</Codenesium>*/