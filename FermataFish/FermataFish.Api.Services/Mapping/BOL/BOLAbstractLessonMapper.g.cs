using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractLessonMapper
	{
		public virtual BOLesson MapModelToBO(
			int id,
			ApiLessonRequestModel model
			)
		{
			BOLesson BOLesson = new BOLesson();

			BOLesson.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.LessonStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNotes,
				model.StudioId,
				model.TeacherNotes);
			return BOLesson;
		}

		public virtual ApiLessonResponseModel MapBOToModel(
			BOLesson BOLesson)
		{
			if (BOLesson == null)
			{
				return null;
			}

			var model = new ApiLessonResponseModel();

			model.SetProperties(BOLesson.ActualEndDate, BOLesson.ActualStartDate, BOLesson.BillAmount, BOLesson.Id, BOLesson.LessonStatusId, BOLesson.ScheduledEndDate, BOLesson.ScheduledStartDate, BOLesson.StudentNotes, BOLesson.StudioId, BOLesson.TeacherNotes);

			return model;
		}

		public virtual List<ApiLessonResponseModel> MapBOToModel(
			List<BOLesson> BOs)
		{
			List<ApiLessonResponseModel> response = new List<ApiLessonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cbfd01c114df7caf552d288ded593b39</Hash>
</Codenesium>*/