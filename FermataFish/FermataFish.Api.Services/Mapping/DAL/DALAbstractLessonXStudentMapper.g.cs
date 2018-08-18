using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractLessonXStudentMapper
	{
		public virtual LessonXStudent MapBOToEF(
			BOLessonXStudent bo)
		{
			LessonXStudent efLessonXStudent = new LessonXStudent();
			efLessonXStudent.SetProperties(
				bo.Id,
				bo.LessonId,
				bo.StudentId);
			return efLessonXStudent;
		}

		public virtual BOLessonXStudent MapEFToBO(
			LessonXStudent ef)
		{
			var bo = new BOLessonXStudent();

			bo.SetProperties(
				ef.Id,
				ef.LessonId,
				ef.StudentId);
			return bo;
		}

		public virtual List<BOLessonXStudent> MapEFToBO(
			List<LessonXStudent> records)
		{
			List<BOLessonXStudent> response = new List<BOLessonXStudent>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02b46bfca1d1ab1f0b9d9e1e6a76a21a</Hash>
</Codenesium>*/