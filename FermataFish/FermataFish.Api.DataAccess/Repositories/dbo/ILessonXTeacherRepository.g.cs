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

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ad668419eea1ab68e2f30a480f9b7a65</Hash>
</Codenesium>*/