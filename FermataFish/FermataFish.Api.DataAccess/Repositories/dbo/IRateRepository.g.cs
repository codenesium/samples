using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		POCORate Create(ApiRateModel model);

		void Update(int id,
		            ApiRateModel model);

		void Delete(int id);

		POCORate Get(int id);

		List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f004c8138a43680411e28ddeeef4af8f</Hash>
</Codenesium>*/