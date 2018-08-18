using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractLessonXTeacherMapper
	{
		public virtual LessonXTeacher MapBOToEF(
			BOLessonXTeacher bo)
		{
			LessonXTeacher efLessonXTeacher = new LessonXTeacher();
			efLessonXTeacher.SetProperties(
				bo.Id,
				bo.LessonId,
				bo.StudentId);
			return efLessonXTeacher;
		}

		public virtual BOLessonXTeacher MapEFToBO(
			LessonXTeacher ef)
		{
			var bo = new BOLessonXTeacher();

			bo.SetProperties(
				ef.Id,
				ef.LessonId,
				ef.StudentId);
			return bo;
		}

		public virtual List<BOLessonXTeacher> MapEFToBO(
			List<LessonXTeacher> records)
		{
			List<BOLessonXTeacher> response = new List<BOLessonXTeacher>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9a8e621c89c4195392a4344de87013a1</Hash>
</Codenesium>*/