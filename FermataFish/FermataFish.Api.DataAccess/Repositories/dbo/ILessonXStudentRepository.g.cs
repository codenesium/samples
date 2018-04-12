using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		int Create(
			int lessonId,
			int studentId);

		void Update(int id,
		            int lessonId,
		            int studentId);

		void Delete(int id);

		Response GetById(int id);

		POCOLessonXStudent GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXStudent> GetWhereDirect(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e2afa08363684dff274278a1a82bde58</Hash>
</Codenesium>*/