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
		Task<CreateResponse<POCOProductListPriceHistory>> Create(
			ApiProductListPriceHistoryModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductListPriceHistoryModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductListPriceHistory Get(int productID);

		List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3c34c41f5d57e337ca3172906a871160</Hash>
</Codenesium>*/