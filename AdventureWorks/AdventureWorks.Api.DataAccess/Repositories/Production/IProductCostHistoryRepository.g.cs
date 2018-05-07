using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		int Create(ProductCostHistoryModel model);

		void Update(int productID,
		            ProductCostHistoryModel model);

		void Delete(int productID);

		POCOProductCostHistory Get(int productID);

		List<POCOProductCostHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d5e363c2e91624361c6e512c4360c2bd</Hash>
</Codenesium>*/