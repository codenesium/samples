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
			ApiLessonXTeacherModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonXTeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c6f7b372dd57f832d2dccc62203bd10b</Hash>
</Codenesium>*/