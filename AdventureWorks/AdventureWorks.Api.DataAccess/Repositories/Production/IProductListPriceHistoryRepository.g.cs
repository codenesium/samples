using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductListPriceHistoryRepository
	{
		Task<ProductListPriceHistory> Create(ProductListPriceHistory item);

		Task Update(ProductListPriceHistory item);

		Task Delete(int productID);

		Task<ProductListPriceHistory> Get(int productID);

		Task<List<ProductListPriceHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2223d29e0167b002af392cb94fbd0b7b</Hash>
</Codenesium>*/