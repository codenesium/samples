using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		POCOState Create(StateModel model);

		void Update(int id,
		            StateModel model);

		void Delete(int id);

		POCOState Get(int id);

		List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>10a7c530114be78a038768b9a68aca38</Hash>
</Codenesium>*/