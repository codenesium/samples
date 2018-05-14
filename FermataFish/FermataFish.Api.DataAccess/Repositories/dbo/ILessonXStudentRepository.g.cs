using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		POCOLessonXStudent Create(LessonXStudentModel model);

		void Update(int id,
		            LessonXStudentModel model);

		void Delete(int id);

		POCOLessonXStudent Get(int id);

		List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>42e4628e735c00a2d37ee3af10ae44d5</Hash>
</Codenesium>*/