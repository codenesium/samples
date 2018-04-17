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
		Task<CreateResponse<int>> Create(
			LessonModel model);

		Task<ActionResponse> Update(int id,
		                            LessonModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOLesson GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLesson> GetWhereDirect(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ed2c0619c997481befff6b4c00d43bdb</Hash>
</Codenesium>*/