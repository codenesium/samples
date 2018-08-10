using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IWorkOrderService
	{
		Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model);

		Task<UpdateResponse<ApiWorkOrderResponseModel>> Update(int workOrderID,
		                                                        ApiWorkOrderRequestModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<ApiWorkOrderResponseModel> Get(int workOrderID);

		Task<List<ApiWorkOrderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderResponseModel>> ByProductID(int productID);

		Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(short? scrapReasonID);

		Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>09703c10cb98b1fb29cf24cb9a5a1485</Hash>
</Codenesium>*/