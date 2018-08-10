using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiPersonRefModelMapper
	{
		ApiPersonRefResponseModel MapRequestToResponse(
			int id,
			ApiPersonRefRequestModel request);

		ApiPersonRefRequestModel MapResponseToRequest(
			ApiPersonRefResponseModel response);

		JsonPatchDocument<ApiPersonRefRequestModel> CreatePatch(ApiPersonRefRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b31d2d21cc66f09f780210e97be839a1</Hash>
</Codenesium>*/