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

		Task<POCOProductReview> Get(int productReviewID);

		Task<List<POCOProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOProductReview>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>ef8dbd690e3f9bcbf718c604a51d5d9c</Hash>
</Codenesium>*/