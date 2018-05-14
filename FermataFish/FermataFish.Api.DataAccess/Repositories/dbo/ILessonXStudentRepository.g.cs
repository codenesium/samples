using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		POCOLessonXStudent Create(ApiLessonXStudentModel model);

		void Update(int id,
		            ApiLessonXStudentModel model);

		void Delete(int id);

		POCOLessonXStudent Get(int id);

		List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>53110461de666618eb50188caa690bb6</Hash>
</Codenesium>*/