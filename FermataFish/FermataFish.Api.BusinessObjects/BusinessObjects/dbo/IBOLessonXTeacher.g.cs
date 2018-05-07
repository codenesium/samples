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
		Task<CreateResponse<int>> Create(
			LessonXTeacherModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXTeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonXTeacher Get(int id);

		List<POCOLessonXTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7a36707e3d6331f957de61c0c9f44fb5</Hash>
</Codenesium>*/