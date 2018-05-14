using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonStatus
	{
		Task<CreateResponse<POCOLessonStatus>> Create(
			ApiLessonStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonStatus Get(int id);

		List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e2990ea87cb15be1f24511e434faa31</Hash>
</Codenesium>*/