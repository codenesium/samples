using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiEmailAddressModelMapper
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
    <Hash>b1c6e7b14c489688361c0b707734789c</Hash>
</Codenesium>*/