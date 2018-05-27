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
		Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
			ApiProductListPriceHistoryRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductListPriceHistoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductListPriceHistoryResponseModel> Get(int productID);

		Task<List<ApiProductListPriceHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9099d3629b1c9bdd0200df7ac409f58c</Hash>
</Codenesium>*/