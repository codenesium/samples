using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLessonMapper
	{
		public virtual DTOLesson MapModelToDTO(
			int id,
			ApiLessonRequestModel model
			)
		{
			DTOLesson dtoLesson = new DTOLesson();

			dtoLesson.SetProperties(
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
			return dtoLesson;
		}

		public virtual ApiLessonResponseModel MapDTOToModel(
			DTOLesson dtoLesson)
		{
			if (dtoLesson == null)
			{
				return null;
			}

			var model = new ApiLessonResponseModel();

			model.SetProperties(dtoLesson.ActualEndDate, dtoLesson.ActualStartDate, dtoLesson.BillAmount, dtoLesson.Id, dtoLesson.LessonStatusId, dtoLesson.ScheduledEndDate, dtoLesson.ScheduledStartDate, dtoLesson.StudentNotes, dtoLesson.StudioId, dtoLesson.TeacherNotes);

			return model;
		}

		public virtual List<ApiLessonResponseModel> MapDTOToModel(
			List<DTOLesson> dtos)
		{
			List<ApiLessonResponseModel> response = new List<ApiLessonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f416bbc9eed1299f2dec5ad560be570b</Hash>
</Codenesium>*/