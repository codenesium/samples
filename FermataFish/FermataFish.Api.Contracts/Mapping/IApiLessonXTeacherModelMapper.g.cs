using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiLessonXTeacherModelMapper
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
    <Hash>15f97b37578379100f0245e492cd81b7</Hash>
</Codenesium>*/