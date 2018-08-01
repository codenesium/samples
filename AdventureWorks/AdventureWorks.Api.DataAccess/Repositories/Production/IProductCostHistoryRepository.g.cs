using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		Task<ProductCostHistory> Create(ProductCostHistory item);

		Task Update(ProductCostHistory item);

		Task Delete(int productID);

		Task<ProductCostHistory> Get(int productID);

		Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4ac81a2a7eb774f7c3d6da60c0dd8371</Hash>
</Codenesium>*/