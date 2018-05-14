using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		POCOLessonXTeacher Create(ApiLessonXTeacherModel model);

		void Update(int id,
		            ApiLessonXTeacherModel model);

		void Delete(int id);

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>909edf3fa70998e063bc9ba6d43e28eb</Hash>
</Codenesium>*/