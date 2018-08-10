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
    <Hash>a32035cd7c1c6940d3056a5b4315bb18</Hash>
</Codenesium>*/