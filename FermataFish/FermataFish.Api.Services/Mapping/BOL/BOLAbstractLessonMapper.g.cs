using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractLessonMapper
	{
		public virtual BOLesson MapModelToBO(
			int id,
			ApiLessonRequestModel model
			)
		{
			BOLesson boLesson = new BOLesson();
			boLesson.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.LessonStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNote,
				model.TeacherNote,
				model.StudioId);
			return boLesson;
		}

		public virtual ApiLessonResponseModel MapBOToModel(
			BOLesson boLesson)
		{
			var model = new ApiLessonResponseModel();

			model.SetProperties(boLesson.Id, boLesson.ActualEndDate, boLesson.ActualStartDate, boLesson.BillAmount, boLesson.LessonStatusId, boLesson.ScheduledEndDate, boLesson.ScheduledStartDate, boLesson.StudentNote, boLesson.TeacherNote, boLesson.StudioId);

			return model;
		}

		public virtual List<ApiLessonResponseModel> MapBOToModel(
			List<BOLesson> items)
		{
			List<ApiLessonResponseModel> response = new List<ApiLessonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ee0ae921a704b7bf6d53468edef03914</Hash>
</Codenesium>*/