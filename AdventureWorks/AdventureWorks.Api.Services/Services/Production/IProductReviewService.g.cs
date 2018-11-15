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

		Task<List<ApiProductReviewServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductReviewServerResponseModel>> ByProductIDReviewerName(int productID, string reviewerName, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b5451a5a80405f96891f679eb28a665c</Hash>
</Codenesium>*/