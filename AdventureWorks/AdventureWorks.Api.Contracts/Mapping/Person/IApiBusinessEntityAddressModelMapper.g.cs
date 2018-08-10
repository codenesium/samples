using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiBusinessEntityAddressModelMapper
	{
		ApiBusinessEntityAddressResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel request);

		ApiBusinessEntityAddressRequestModel MapResponseToRequest(
			ApiBusinessEntityAddressResponseModel response);

		JsonPatchDocument<ApiBusinessEntityAddressRequestModel> CreatePatch(ApiBusinessEntityAddressRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0d85733876ca1b603b419c0b296182b5</Hash>
</Codenesium>*/