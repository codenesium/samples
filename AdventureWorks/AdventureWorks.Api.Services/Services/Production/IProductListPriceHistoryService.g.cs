using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductListPriceHistoryService
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
    <Hash>be16826f3b5ea5f58a3635ec7fbfbd9a</Hash>
</Codenesium>*/