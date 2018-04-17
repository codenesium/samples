using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacher
	{
		Task<CreateResponse<int>> Create(
			TeacherModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOTeacher GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacher> GetWhereDirect(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e4e2622aaf5168b493d3858056356eae</Hash>
</Codenesium>*/