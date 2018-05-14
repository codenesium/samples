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

		POCOLessonXStudent Get(int id);

		List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>035c3a2cd30f2f49f42d3e97025b246b</Hash>
</Codenesium>*/