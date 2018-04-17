using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXTeacher
	{
		Task<CreateResponse<int>> Create(
			LessonXTeacherModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXTeacherModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLessonXTeacher GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLessonXTeacher> GetWhereDirect(Expression<Func<EFLessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9f2b30279e472d544fa16488bcf7af0c</Hash>
</Codenesium>*/