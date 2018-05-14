using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXTeacher
	{
		Task<CreateResponse<POCOLessonXTeacher>> Create(
			LessonXTeacherModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXTeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cec89b1a6636ed7c4ad71e38f4be49e2</Hash>
</Codenesium>*/