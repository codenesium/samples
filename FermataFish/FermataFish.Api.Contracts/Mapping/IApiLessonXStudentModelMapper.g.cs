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
    <Hash>e83b9141c414dc596ceb37f61673c591</Hash>
</Codenesium>*/