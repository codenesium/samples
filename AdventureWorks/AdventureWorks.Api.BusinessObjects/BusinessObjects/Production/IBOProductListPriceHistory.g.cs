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

		Task<POCOProductListPriceHistory> Get(int productID);

		Task<List<POCOProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f518086480e0d598d9455c840ca8088c</Hash>
</Codenesium>*/