using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiStateProvinceModelMapper
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
    <Hash>c07f6f89f91c261bbf90a18b2e62ce51</Hash>
</Codenesium>*/