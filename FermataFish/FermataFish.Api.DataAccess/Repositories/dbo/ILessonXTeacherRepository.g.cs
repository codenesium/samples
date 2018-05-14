using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		POCOLessonXTeacher Create(LessonXTeacherModel model);

		void Update(int id,
		            LessonXTeacherModel model);

		void Delete(int id);

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d4e917437da03bc24f9cfcf3929e3c3d</Hash>
</Codenesium>*/