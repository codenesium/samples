using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXStudent
	{
		Task<CreateResponse<POCOLessonXStudent>> Create(
			ApiLessonXStudentModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonXStudentModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOLessonXStudent> Get(int id);

		Task<List<POCOLessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d2fe783792523049d4fe7efc8adabb74</Hash>
</Codenesium>*/