using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOAdmin
	{
		Task<CreateResponse<int>> Create(
			AdminModel model);

		Task<ActionResponse> Update(int id,
		                            AdminModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOAdmin GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAdmin> GetWhereDirect(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7f24e0ddfa93ff513dbfb6d74f9cd658</Hash>
</Codenesium>*/