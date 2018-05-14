using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		POCOState Create(ApiStateModel model);

		void Update(int id,
		            ApiStateModel model);

		void Delete(int id);

		POCOState Get(int id);

		List<POCOState> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae2bb6bd3c174bcef151134fd79247a3</Hash>
</Codenesium>*/