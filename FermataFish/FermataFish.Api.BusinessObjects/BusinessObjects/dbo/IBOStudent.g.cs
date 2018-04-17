using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudent
	{
		Task<CreateResponse<int>> Create(
			StudentModel model);

		Task<ActionResponse> Update(int id,
		                            StudentModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOStudent GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudent> GetWhereDirect(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cde603c245d393f2afad4b3f8896a8ec</Hash>
</Codenesium>*/