using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductListPriceHistory
	{
		Task<CreateResponse<int>> Create(
			ProductListPriceHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductListPriceHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductListPriceHistory Get(int productID);

		List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bcafcc7a874797808ba962ce6e06e4df</Hash>
</Codenesium>*/