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
		Task<CreateResponse<int>> Create(
			LessonModel model);

		Task<ActionResponse> Update(int id,
		                            LessonModel model);

		Task<ActionResponse> Delete(int id);

		POCOLesson Get(int id);

		List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>31aae2cba65c85ce1068fcd414ad822a</Hash>
</Codenesium>*/