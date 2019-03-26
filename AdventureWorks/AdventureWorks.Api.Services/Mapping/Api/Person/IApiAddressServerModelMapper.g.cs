using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressServerModelMapper
	{
		ApiAddressServerResponseModel MapServerRequestToResponse(
			int addressID,
			ApiAddressServerRequestModel request);

		ApiAddressServerRequestModel MapServerResponseToRequest(
			ApiAddressServerResponseModel response);

		ApiAddressClientRequestModel MapServerResponseToClientRequest(
			ApiAddressServerResponseModel response);

		JsonPatchDocument<ApiAddressServerRequestModel> CreatePatch(ApiAddressServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>37d43e496fd6f60b8b77e121786b9514</Hash>
</Codenesium>*/