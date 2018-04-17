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
		Task<CreateResponse<int>> Create(
			LessonXStudentModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXStudentModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLessonXStudent GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXStudent> GetWhereDirect(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c733201d9eecbd9d4b145dfbe21c32b</Hash>
</Codenesium>*/