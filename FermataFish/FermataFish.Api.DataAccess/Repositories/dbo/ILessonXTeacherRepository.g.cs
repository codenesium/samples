using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		int Create(LessonXTeacherModel model);

		void Update(int id,
		            LessonXTeacherModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLessonXTeacher GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXTeacher> GetWhereDirect(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>77c62f06db4f4fe479170acbb0d36fa9</Hash>
</Codenesium>*/