using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		int Create(LessonModel model);

		void Update(int id,
		            LessonModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLesson GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLesson> GetWhereDirect(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>05cc9c4c26a651993e75018e0e2535b2</Hash>
</Codenesium>*/