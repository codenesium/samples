using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		Task<POCOSalesPerson> Create(ApiSalesPersonModel model);

		Task Update(int businessEntityID,
		            ApiSalesPersonModel model);

		Task Delete(int businessEntityID);

		Task<POCOSalesPerson> Get(int businessEntityID);

		Task<List<POCOSalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d55c8fd4485bfe9711298ae0e52ff13e</Hash>
</Codenesium>*/