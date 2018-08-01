using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiLessonModelMapper
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
    <Hash>9d81cc06d0f4bfd39b85fee2d19db53e</Hash>
</Codenesium>*/