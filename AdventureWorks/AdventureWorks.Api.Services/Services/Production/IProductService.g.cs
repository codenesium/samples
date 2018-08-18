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

		Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductInventoryResponseModel>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductReviewResponseModel>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryResponseModel>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderResponseModel>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3c38bb8208a0d3fd3572c2b48aa031ca</Hash>
</Codenesium>*/