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
    <Hash>da1e7f805fee587b811d41d8ea537507</Hash>
</Codenesium>*/