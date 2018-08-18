using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPasswordModelMapper
	{
		ApiPasswordResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPasswordRequestModel request);

		ApiPasswordRequestModel MapResponseToRequest(
			ApiPasswordResponseModel response);

		JsonPatchDocument<ApiPasswordRequestModel> CreatePatch(ApiPasswordRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1151ecdc1e9b88af90e9ffccc5f9abb7</Hash>
</Codenesium>*/