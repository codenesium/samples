using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALLessonMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLesson dto,
			Lesson efLesson)
		{
			efLesson.SetProperties(
				id,
				dto.ActualEndDate,
				dto.ActualStartDate,
				dto.BillAmount,
				dto.LessonStatusId,
				dto.ScheduledEndDate,
				dto.ScheduledStartDate,
				dto.StudentNotes,
				dto.StudioId,
				dto.TeacherNotes);
		}

		public virtual DTOLesson MapEFToDTO(
			Lesson ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLesson();

			dto.SetProperties(
				ef.Id,
				ef.ActualEndDate,
				ef.ActualStartDate,
				ef.BillAmount,
				ef.LessonStatusId,
				ef.ScheduledEndDate,
				ef.ScheduledStartDate,
				ef.StudentNotes,
				ef.StudioId,
				ef.TeacherNotes);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>501f448a39f53dcf8038b0bbe7883ba5</Hash>
</Codenesium>*/