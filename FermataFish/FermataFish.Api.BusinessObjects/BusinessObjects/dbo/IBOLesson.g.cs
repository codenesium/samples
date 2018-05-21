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

		Task<POCOLesson> Get(int id);

		Task<List<POCOLesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>934787871d6c03f9a0baab1297ee07f2</Hash>
</Codenesium>*/