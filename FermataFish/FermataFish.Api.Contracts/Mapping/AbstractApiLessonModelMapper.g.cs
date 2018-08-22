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
			                       request.StudentNote,
			                       request.TeacherNote,
			                       request.StudioId);
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
				response.StudentNote,
				response.TeacherNote,
				response.StudioId);
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
			patch.Replace(x => x.StudentNote, model.StudentNote);
			patch.Replace(x => x.TeacherNote, model.TeacherNote);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>51e7df0125904c6e62f7fccead1c4601</Hash>
</Codenesium>*/