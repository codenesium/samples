using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiStateProvinceModelMapper
	{
		ApiStateProvinceResponseModel MapRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceRequestModel request);

		ApiStateProvinceRequestModel MapResponseToRequest(
			ApiStateProvinceResponseModel response);

		JsonPatchDocument<ApiStateProvinceRequestModel> CreatePatch(ApiStateProvinceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>176504ce7f9a828d41a3e32b55141595</Hash>
</Codenesium>*/