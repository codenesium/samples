using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductReviewRepository
	{
		Task<ProductReview> Create(ProductReview item);

		Task Update(ProductReview item);

		Task Delete(int productReviewID);

		Task<ProductReview> Get(int productReviewID);

		Task<List<ProductReview>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ProductReview>> ByProductIDReviewerName(int productID, string reviewerName, int limit = int.MaxValue, int offset = 0);

		Task<Product> ProductByProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>00d457d4de7e5c6a67c40fdbfbcdc1a6</Hash>
</Codenesium>*/