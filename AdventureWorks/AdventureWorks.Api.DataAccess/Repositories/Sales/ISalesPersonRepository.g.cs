using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		Task<SalesPerson> Create(SalesPerson item);

		Task Update(SalesPerson item);

		Task Delete(int businessEntityID);

		Task<SalesPerson> Get(int businessEntityID);

		Task<List<SalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bb399936480e09ea5180cfab9253d252</Hash>
</Codenesium>*/