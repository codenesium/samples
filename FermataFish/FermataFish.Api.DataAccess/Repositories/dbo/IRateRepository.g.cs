using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		int Create(RateModel model);

		void Update(int id,
		            RateModel model);

		void Delete(int id);

		POCORate Get(int id);

		List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>46fe6227760f51c4826189f9f0dd6c27</Hash>
</Codenesium>*/