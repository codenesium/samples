using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiLessonStatusModelMapper
	{
		ApiLessonStatusResponseModel MapRequestToResponse(
			int id,
			ApiLessonStatusRequestModel request);

		ApiLessonStatusRequestModel MapResponseToRequest(
			ApiLessonStatusResponseModel response);

		JsonPatchDocument<ApiLessonStatusRequestModel> CreatePatch(ApiLessonStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6cac1285af5f2390c80bde81b8d5115a</Hash>
</Codenesium>*/