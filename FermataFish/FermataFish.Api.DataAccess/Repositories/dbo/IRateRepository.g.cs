using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		Task<POCORate> Create(ApiRateModel model);

		Task Update(int id,
		            ApiRateModel model);

		Task Delete(int id);

		Task<POCORate> Get(int id);

		Task<List<POCORate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>24de0545c9deb9c2755feb8fb2aaf9cb</Hash>
</Codenesium>*/