using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPurchaseOrderHeaderService
	{
		Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model);

		Task<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>> Update(int purchaseOrderID,
		                                                                  ApiPurchaseOrderHeaderRequestModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> ByEmployeeID(int employeeID);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> ByVendorID(int vendorID);

		Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dc7a1e3a613fb28a29911fe8d58e4410</Hash>
</Codenesium>*/