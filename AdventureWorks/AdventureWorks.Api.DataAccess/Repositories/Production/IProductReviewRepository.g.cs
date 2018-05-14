using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		POCOProductReview Create(ApiProductReviewModel model);

		void Update(int productReviewID,
		            ApiProductReviewModel model);

		void Delete(int productReviewID);

		POCOProductReview Get(int productReviewID);

		List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductReview> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>387ef51f855d4e4751e6f3e18525c5c3</Hash>
</Codenesium>*/