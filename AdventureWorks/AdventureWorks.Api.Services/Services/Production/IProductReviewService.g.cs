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

		Task<List<ApiProductReviewResponseModel>> ByProductIDReviewerName(int productID, string reviewerName);
	}
}

/*<Codenesium>
    <Hash>cba1dc1d07c231590ef3ce6a8a722bba</Hash>
</Codenesium>*/