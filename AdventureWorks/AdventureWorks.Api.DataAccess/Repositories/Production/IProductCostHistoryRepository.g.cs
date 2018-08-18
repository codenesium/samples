using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductCostHistoryRepository
	{
		Task<ProductCostHistory> Create(ProductCostHistory item);

		Task Update(ProductCostHistory item);

		Task Delete(int productID);

		Task<ProductCostHistory> Get(int productID);

		Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>af102ba50f30b4d10402b04f5fbf6d69</Hash>
</Codenesium>*/