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
    <Hash>0a83991ef7a67072caf4b4311f2c88c0</Hash>
</Codenesium>*/