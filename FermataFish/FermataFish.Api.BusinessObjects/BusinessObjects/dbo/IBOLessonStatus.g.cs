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

		ApiResponse GetById(int id);

		POCOLessonStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonStatus> GetWhereDirect(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>685b18a10a7e92db27243a463034c381</Hash>
</Codenesium>*/