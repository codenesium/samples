using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IWorkOrderService
	{
		Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            ApiWorkOrderRequestModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<ApiWorkOrderResponseModel> Get(int workOrderID);

		Task<List<ApiWorkOrderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiWorkOrderResponseModel>> GetProductID(int productID);
		Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>a98d6743c26692fda6273ed0b6c25ca6</Hash>
</Codenesium>*/