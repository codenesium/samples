using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiLessonXStudentModelMapper
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
    <Hash>dbccdc1ac87846b386b03729a14b0eda</Hash>
</Codenesium>*/