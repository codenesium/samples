using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTimestampCheckModelMapper
	{
		ApiTimestampCheckResponseModel MapRequestToResponse(
			int id,
			ApiTimestampCheckRequestModel request);

		ApiTimestampCheckRequestModel MapResponseToRequest(
			ApiTimestampCheckResponseModel response);

		JsonPatchDocument<ApiTimestampCheckRequestModel> CreatePatch(ApiTimestampCheckRequestModel model);
	}
}

/*<Codenesium>
    <Hash>735020cbed848ce2b8a3943edbbe9604</Hash>
</Codenesium>*/