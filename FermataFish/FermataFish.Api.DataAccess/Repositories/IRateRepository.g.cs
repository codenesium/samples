using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		Task<Rate> Create(Rate item);

		Task Update(Rate item);

		Task Delete(int id);

		Task<Rate> Get(int id);

		Task<List<Rate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1e796669a45264592465c96054757834</Hash>
</Codenesium>*/