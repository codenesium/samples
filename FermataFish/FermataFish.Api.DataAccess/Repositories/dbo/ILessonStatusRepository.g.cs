using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		int Create(
			string name,
			int studioId);

		void Update(int id,
		            string name,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOLessonStatus GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonStatus> GetWhereDirect(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ffa2f95b77ad599ee544fa82beb8957d</Hash>
</Codenesium>*/