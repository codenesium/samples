using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		int Create(
			int lessonId,
			int studentId);

		void Update(int id,
		            int lessonId,
		            int studentId);

		void Delete(int id);

		Response GetById(int id);

		POCOLessonXTeacher GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXTeacher> GetWhereDirect(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>59969eb32f2ee0cc148896e6ab0ed558</Hash>
</Codenesium>*/