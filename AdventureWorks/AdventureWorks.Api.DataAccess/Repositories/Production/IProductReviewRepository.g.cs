using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductReviewRepository
	{
		Task<ProductReview> Create(ProductReview item);

		Task Update(ProductReview item);

		Task Delete(int productReviewID);

		Task<ProductReview> Get(int productReviewID);

		Task<List<ProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ProductReview>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName);
	}
}

/*<Codenesium>
    <Hash>b7920e986b08b736dfb918c5e5bf2216</Hash>
</Codenesium>*/