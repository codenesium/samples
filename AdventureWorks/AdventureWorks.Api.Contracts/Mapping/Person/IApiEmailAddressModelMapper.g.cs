using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiEmailAddressModelMapper
	{
		ApiEmailAddressResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmailAddressRequestModel request);

		ApiEmailAddressRequestModel MapResponseToRequest(
			ApiEmailAddressResponseModel response);

		JsonPatchDocument<ApiEmailAddressRequestModel> CreatePatch(ApiEmailAddressRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fc886b034f688ab61a681ea233c334c5</Hash>
</Codenesium>*/