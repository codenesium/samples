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

		Task<List<ApiPurchaseOrderHeaderResponseModel>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderHeaderResponseModel>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetailsByPurchaseOrderID(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1b1eb0d1f31c69f449808852f007d930</Hash>
</Codenesium>*/