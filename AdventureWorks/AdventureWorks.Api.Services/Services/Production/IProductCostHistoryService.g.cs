using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductCostHistoryService
	{
		Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model);

		Task<UpdateResponse<ApiProductCostHistoryResponseModel>> Update(int productID,
		                                                                 ApiProductCostHistoryRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductCostHistoryResponseModel> Get(int productID);

		Task<List<ApiProductCostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>09ffd72062b86cf0d236736853ee7f85</Hash>
</Codenesium>*/