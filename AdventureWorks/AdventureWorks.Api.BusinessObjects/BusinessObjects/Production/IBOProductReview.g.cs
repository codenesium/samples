using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductReview
	{
		Task<CreateResponse<ApiProductReviewResponseModel>> Create(
			ApiProductReviewRequestModel model);

		Task<ActionResponse> Update(int productReviewID,
		                            ApiProductReviewRequestModel model);

		Task<ActionResponse> Delete(int productReviewID);

		Task<ApiProductReviewResponseModel> Get(int productReviewID);

		Task<List<ApiProductReviewResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiProductReviewResponseModel>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>2c4fc617bf751baa9c0243b5349cbb0d</Hash>
</Codenesium>*/