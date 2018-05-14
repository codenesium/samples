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
			LessonStatusModel model);

		Task<ActionResponse> Update(int id,
		                            LessonStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonStatus Get(int id);

		List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84bd3fa9954850df67abad28a3abcf5d</Hash>
</Codenesium>*/