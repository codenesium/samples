using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBORate
	{
		Task<CreateResponse<int>> Create(
			RateModel model);

		Task<ActionResponse> Update(int id,
		                            RateModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCORate GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0653795eaecfd59397e47edf82f046db</Hash>
</Codenesium>*/