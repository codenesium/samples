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
    <Hash>8b224da9039acad812702aecbdc16c97</Hash>
</Codenesium>*/