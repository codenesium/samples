using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		int Create(StateModel model);

		void Update(int id,
		            StateModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOState GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFState, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOState> GetWhereDirect(Expression<Func<EFState, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>23648b1770ae78f3b0969d90fa85481c</Hash>
</Codenesium>*/