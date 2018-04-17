using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOState
	{
		Task<CreateResponse<int>> Create(
			StateModel model);

		Task<ActionResponse> Update(int id,
		                            StateModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOState GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFState, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOState> GetWhereDirect(Expression<Func<EFState, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ef794c073eaca11ed1eea34bdd542920</Hash>
</Codenesium>*/