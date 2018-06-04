using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		Task<ProductListPriceHistory> Create(ProductListPriceHistory item);

		Task Update(ProductListPriceHistory item);

		Task Delete(int productID);

		Task<ProductListPriceHistory> Get(int productID);

		Task<List<ProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a494ef0e1a1e639c4bc48cdedf3505e</Hash>
</Codenesium>*/