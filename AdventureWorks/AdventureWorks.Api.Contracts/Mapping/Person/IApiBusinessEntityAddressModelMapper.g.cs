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
    <Hash>de1ce4eb68d0fd9ab23ccf536085cc5a</Hash>
</Codenesium>*/