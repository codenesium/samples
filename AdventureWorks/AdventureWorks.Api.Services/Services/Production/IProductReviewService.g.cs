using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductReviewService
	{
		Task<CreateResponse<ApiProductReviewServerResponseModel>> Create(
			ApiProductReviewServerRequestModel model);

		Task<UpdateResponse<ApiProductReviewServerResponseModel>> Update(int productReviewID,
		                                                                  ApiProductReviewServerRequestModel model);

		Task<ActionResponse> Delete(int productReviewID);

		Task<ApiProductReviewServerResponseModel> Get(int productReviewID);

		Task<List<ApiProductReviewServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiProductReviewServerResponseModel>> ByProductIDReviewerName(int productID, string reviewerName, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fd52a5fd6c5745d4b611cf163f2ac337</Hash>
</Codenesium>*/