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
    <Hash>c74098d04bf110db1526a9ae2b86d5a2</Hash>
</Codenesium>*/