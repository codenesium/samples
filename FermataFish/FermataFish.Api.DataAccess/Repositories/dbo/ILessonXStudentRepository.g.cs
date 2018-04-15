using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		int Create(LessonXStudentModel model);

		void Update(int id,
		            LessonXStudentModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLessonXStudent GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXStudent> GetWhereDirect(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>58ff692fde93183e196323945164fda3</Hash>
</Codenesium>*/