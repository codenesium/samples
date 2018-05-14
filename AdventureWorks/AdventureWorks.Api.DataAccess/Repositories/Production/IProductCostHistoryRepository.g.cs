using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		POCOProductCostHistory Create(ApiProductCostHistoryModel model);

		void Update(int productID,
		            ApiProductCostHistoryModel model);

		void Delete(int productID);

		POCOProductCostHistory Get(int productID);

		List<POCOProductCostHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>93bfecdb5cbccd846252e39043b65f02</Hash>
</Codenesium>*/