using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductReviewService
	{
		Task<CreateResponse<ApiProductReviewResponseModel>> Create(
			ApiProductReviewRequestModel model);

		Task<UpdateResponse<ApiProductReviewResponseModel>> Update(int productReviewID,
		                                                            ApiProductReviewRequestModel model);

		Task<ActionResponse> Delete(int productReviewID);

		Task<ApiProductReviewResponseModel> Get(int productReviewID);

		Task<List<ApiProductReviewResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductReviewResponseModel>> ByProductIDReviewerName(int productID, string reviewerName, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>03c37f20fed362312fbce91665f0a64e</Hash>
</Codenesium>*/