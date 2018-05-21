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

		Task<POCOLessonStatus> Get(int id);

		Task<List<POCOLessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1267d4feed8bb3d047c7b5352b0c6c91</Hash>
</Codenesium>*/