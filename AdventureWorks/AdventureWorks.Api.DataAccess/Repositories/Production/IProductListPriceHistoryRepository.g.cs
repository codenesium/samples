using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		Task<ProductListPriceHistory> Create(ProductListPriceHistory item);

		Task Update(ProductListPriceHistory item);

		Task Delete(int productID);

		Task<ProductListPriceHistory> Get(int productID);

		Task<List<ProductListPriceHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f3abf4ac4807d2a2409a21a325e8e824</Hash>
</Codenesium>*/