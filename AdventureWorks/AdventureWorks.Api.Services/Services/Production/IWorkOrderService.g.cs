using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IWorkOrderService
	{
		Task<CreateResponse<ApiWorkOrderServerResponseModel>> Create(
			ApiWorkOrderServerRequestModel model);

		Task<UpdateResponse<ApiWorkOrderServerResponseModel>> Update(int workOrderID,
		                                                              ApiWorkOrderServerRequestModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<ApiWorkOrderServerResponseModel> Get(int workOrderID);

		Task<List<ApiWorkOrderServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiWorkOrderServerResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderServerResponseModel>> ByScrapReasonID(short? scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ed558e71d900fe75d22f570bb0d29ea7</Hash>
</Codenesium>*/