using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		POCORate Create(RateModel model);

		void Update(int id,
		            RateModel model);

		void Delete(int id);

		POCORate Get(int id);

		List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>12ae5497bf8e56e6e1fa2d14182d7556</Hash>
</Codenesium>*/