using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductListPriceHistoryService
	{
		Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
			ApiProductListPriceHistoryRequestModel model);

		Task<UpdateResponse<ApiProductListPriceHistoryResponseModel>> Update(int productID,
		                                                                      ApiProductListPriceHistoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductListPriceHistoryResponseModel> Get(int productID);

		Task<List<ApiProductListPriceHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4227491c7e1cf9ef0452e5894d1812dd</Hash>
</Codenesium>*/