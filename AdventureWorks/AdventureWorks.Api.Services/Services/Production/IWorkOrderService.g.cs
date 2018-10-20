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

		Task<List<ApiWorkOrderResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(short? scrapReasonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingsByWorkOrderID(int workOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f2ae1417c53fc789d89b161c738f86c9</Hash>
</Codenesium>*/