using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiLessonXTeacherModelMapper
	{
		ApiLessonXTeacherResponseModel MapRequestToResponse(
			int id,
			ApiLessonXTeacherRequestModel request);

		ApiLessonXTeacherRequestModel MapResponseToRequest(
			ApiLessonXTeacherResponseModel response);

		JsonPatchDocument<ApiLessonXTeacherRequestModel> CreatePatch(ApiLessonXTeacherRequestModel model);
	}
}

/*<Codenesium>
    <Hash>af8af3b5d2c84cbd60ed0a4d1ede7dcc</Hash>
</Codenesium>*/