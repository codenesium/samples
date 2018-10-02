using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiCompositePrimaryKeyModelMapper
	{
		ApiCompositePrimaryKeyResponseModel MapRequestToResponse(
			int id,
			ApiCompositePrimaryKeyRequestModel request);

		ApiCompositePrimaryKeyRequestModel MapResponseToRequest(
			ApiCompositePrimaryKeyResponseModel response);

		JsonPatchDocument<ApiCompositePrimaryKeyRequestModel> CreatePatch(ApiCompositePrimaryKeyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>444c1d2d81c151ad68c33b8bbdb73b98</Hash>
</Codenesium>*/