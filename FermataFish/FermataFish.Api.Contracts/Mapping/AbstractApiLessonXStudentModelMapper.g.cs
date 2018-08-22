using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiLessonXStudentModelMapper
	{
		public virtual ApiLessonXStudentResponseModel MapRequestToResponse(
			int id,
			ApiLessonXStudentRequestModel request)
		{
			var response = new ApiLessonXStudentResponseModel();
			response.SetProperties(id,
			                       request.LessonId,
			                       request.StudentId,
			                       request.StudioId);
			return response;
		}

		public virtual ApiLessonXStudentRequestModel MapResponseToRequest(
			ApiLessonXStudentResponseModel response)
		{
			var request = new ApiLessonXStudentRequestModel();
			request.SetProperties(
				response.LessonId,
				response.StudentId,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiLessonXStudentRequestModel> CreatePatch(ApiLessonXStudentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLessonXStudentRequestModel>();
			patch.Replace(x => x.LessonId, model.LessonId);
			patch.Replace(x => x.StudentId, model.StudentId);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3f59ceba022666f46a0ff84f0eea7540</Hash>
</Codenesium>*/