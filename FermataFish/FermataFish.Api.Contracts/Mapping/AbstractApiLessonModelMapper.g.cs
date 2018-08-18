using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiLessonModelMapper
	{
		public virtual ApiLessonResponseModel MapRequestToResponse(
			int id,
			ApiLessonRequestModel request)
		{
			var response = new ApiLessonResponseModel();
			response.SetProperties(id,
			                       request.ActualEndDate,
			                       request.ActualStartDate,
			                       request.BillAmount,
			                       request.LessonStatusId,
			                       request.ScheduledEndDate,
			                       request.ScheduledStartDate,
			                       request.StudentNotes,
			                       request.StudioId,
			                       request.TeacherNotes);
			return response;
		}

		public virtual ApiLessonRequestModel MapResponseToRequest(
			ApiLessonResponseModel response)
		{
			var request = new ApiLessonRequestModel();
			request.SetProperties(
				response.ActualEndDate,
				response.ActualStartDate,
				response.BillAmount,
				response.LessonStatusId,
				response.ScheduledEndDate,
				response.ScheduledStartDate,
				response.StudentNotes,
				response.StudioId,
				response.TeacherNotes);
			return request;
		}

		public JsonPatchDocument<ApiLessonRequestModel> CreatePatch(ApiLessonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLessonRequestModel>();
			patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
			patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
			patch.Replace(x => x.BillAmount, model.BillAmount);
			patch.Replace(x => x.LessonStatusId, model.LessonStatusId);
			patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
			patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
			patch.Replace(x => x.StudentNotes, model.StudentNotes);
			patch.Replace(x => x.StudioId, model.StudioId);
			patch.Replace(x => x.TeacherNotes, model.TeacherNotes);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6e86f8d6b505e334f182ee4271d1404f</Hash>
</Codenesium>*/