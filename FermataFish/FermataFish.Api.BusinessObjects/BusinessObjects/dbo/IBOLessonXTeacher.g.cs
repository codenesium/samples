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

		Task<POCOLessonXTeacher> Get(int id);

		Task<List<POCOLessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ac1e9abef5621b3cbe675805d2b4d88b</Hash>
</Codenesium>*/