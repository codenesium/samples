using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpace
	{
		Task<CreateResponse<int>> Create(
			SpaceModel model);

		Task<ActionResponse> Update(int id,
		                            SpaceModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOSpace GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpace> GetWhereDirect(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5df95aa1930dc628188169862347e39</Hash>
</Codenesium>*/