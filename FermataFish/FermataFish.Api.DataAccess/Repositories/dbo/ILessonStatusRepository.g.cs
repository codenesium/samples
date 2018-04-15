using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		int Create(LessonStatusModel model);

		void Update(int id,
		            LessonStatusModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLessonStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonStatus> GetWhereDirect(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f7bad162536c59b04defcdb090772ac5</Hash>
</Codenesium>*/