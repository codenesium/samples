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
		Task<CreateResponse<POCOProductReview>> Create(
			ApiProductReviewModel model);

		Task<ActionResponse> Update(int productReviewID,
		                            ApiProductReviewModel model);

		Task<ActionResponse> Delete(int productReviewID);

		POCOProductReview Get(int productReviewID);

		List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductReview> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>9afc8491bff080013797543c9e30f3c8</Hash>
</Codenesium>*/