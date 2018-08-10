using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiLessonXStudentModelMapper
	{
		ApiLessonXStudentResponseModel MapRequestToResponse(
			int id,
			ApiLessonXStudentRequestModel request);

		ApiLessonXStudentRequestModel MapResponseToRequest(
			ApiLessonXStudentResponseModel response);

		JsonPatchDocument<ApiLessonXStudentRequestModel> CreatePatch(ApiLessonXStudentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8abb9d9ff9b0e4ddab0e35d881f660ea</Hash>
</Codenesium>*/