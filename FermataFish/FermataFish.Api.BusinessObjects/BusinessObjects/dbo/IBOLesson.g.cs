using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLesson
	{
		Task<CreateResponse<POCOLesson>> Create(
			ApiLessonModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonModel model);

		Task<ActionResponse> Delete(int id);

		POCOLesson Get(int id);

		List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0dfc75cea2a0c1274455b5eb779a55cf</Hash>
</Codenesium>*/