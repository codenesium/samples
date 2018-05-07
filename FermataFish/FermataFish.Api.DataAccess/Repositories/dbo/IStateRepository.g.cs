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

		POCOState Get(int id);

		List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>141536f9e6bea2d5a622a34dff70da6b</Hash>
</Codenesium>*/