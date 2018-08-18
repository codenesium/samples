using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiLessonModelMapper
	{
		ApiLessonResponseModel MapRequestToResponse(
			int id,
			ApiLessonRequestModel request);

		ApiLessonRequestModel MapResponseToRequest(
			ApiLessonResponseModel response);

		JsonPatchDocument<ApiLessonRequestModel> CreatePatch(ApiLessonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9a8573c2d6c0ab0e56007ec0c4d3c2d1</Hash>
</Codenesium>*/