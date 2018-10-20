using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductService
	{
		Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model);

		Task<UpdateResponse<ApiProductResponseModel>> Update(int productID,
		                                                      ApiProductRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductResponseModel> Get(int productID);

		Task<List<ApiProductResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductResponseModel> ByName(string name);

		Task<ApiProductResponseModel> ByProductNumber(string productNumber);

		Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductInventoryResponseModel>> ProductInventoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductReviewResponseModel>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryResponseModel>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderResponseModel>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductResponseModel>> ByDocumentNode(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1c6aeb0bfdcf014219c8c6bbe8e292f8</Hash>
</Codenesium>*/