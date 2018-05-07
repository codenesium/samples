using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		int Create(ProductListPriceHistoryModel model);

		void Update(int productID,
		            ProductListPriceHistoryModel model);

		void Delete(int productID);

		POCOProductListPriceHistory Get(int productID);

		List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9d51793c327e0cd75b1264a5972ac098</Hash>
</Codenesium>*/