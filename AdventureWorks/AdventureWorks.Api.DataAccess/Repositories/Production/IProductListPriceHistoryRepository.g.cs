using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		POCOProductListPriceHistory Create(ApiProductListPriceHistoryModel model);

		void Update(int productID,
		            ApiProductListPriceHistoryModel model);

		void Delete(int productID);

		POCOProductListPriceHistory Get(int productID);

		List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8093ec04bd7cfea19c0c9681891ba028</Hash>
</Codenesium>*/