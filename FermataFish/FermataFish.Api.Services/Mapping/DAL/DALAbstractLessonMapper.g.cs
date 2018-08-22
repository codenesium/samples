using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractLessonMapper
	{
		public virtual Lesson MapBOToEF(
			BOLesson bo)
		{
			Lesson efLesson = new Lesson();
			efLesson.SetProperties(
				bo.Id,
				bo.ActualEndDate,
				bo.ActualStartDate,
				bo.BillAmount,
				bo.LessonStatusId,
				bo.ScheduledEndDate,
				bo.ScheduledStartDate,
				bo.StudentNote,
				bo.TeacherNote,
				bo.StudioId);
			return efLesson;
		}

		public virtual BOLesson MapEFToBO(
			Lesson ef)
		{
			var bo = new BOLesson();

			bo.SetProperties(
				ef.Id,
				ef.ActualEndDate,
				ef.ActualStartDate,
				ef.BillAmount,
				ef.LessonStatusId,
				ef.ScheduledEndDate,
				ef.ScheduledStartDate,
				ef.StudentNote,
				ef.TeacherNote,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOLesson> MapEFToBO(
			List<Lesson> records)
		{
			List<BOLesson> response = new List<BOLesson>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6b3d90cf14bfd24332d97cc964171417</Hash>
</Codenesium>*/