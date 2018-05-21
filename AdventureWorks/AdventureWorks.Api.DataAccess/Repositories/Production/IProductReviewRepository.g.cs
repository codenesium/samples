using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		Task<POCOProductReview> Create(ApiProductReviewModel model);

		Task Update(int productReviewID,
		            ApiProductReviewModel model);

		Task Delete(int productReviewID);

		Task<POCOProductReview> Get(int productReviewID);

		Task<List<POCOProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOProductReview>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>9a45671699cdb60a776e634472f208f0</Hash>
</Codenesium>*/