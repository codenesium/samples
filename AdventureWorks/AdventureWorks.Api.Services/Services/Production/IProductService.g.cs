using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductService
	{
		Task<CreateResponse<ApiProductServerResponseModel>> Create(
			ApiProductServerRequestModel model);

		Task<UpdateResponse<ApiProductServerResponseModel>> Update(int productID,
		                                                            ApiProductServerRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductServerResponseModel> Get(int productID);

		Task<List<ApiProductServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductServerResponseModel> ByName(string name);

		Task<ApiProductServerResponseModel> ByProductNumber(string productNumber);

		Task<ApiProductServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductReviewServerResponseModel>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryServerResponseModel>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4d124fc8e9abd969243fd8886e223b21</Hash>
</Codenesium>*/