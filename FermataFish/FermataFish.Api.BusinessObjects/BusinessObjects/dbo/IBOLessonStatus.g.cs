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
		Task<CreateResponse<int>> Create(
			LessonStatusModel model);

		Task<ActionResponse> Update(int id,
		                            LessonStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonStatus Get(int id);

		List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8cbcf329f164a84bcc7f043a7d138625</Hash>
</Codenesium>*/