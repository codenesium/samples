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

		Task<List<ProductReview>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ProductReview>> ByProductIDReviewerName(int productID, string reviewerName);
	}
}

/*<Codenesium>
    <Hash>14f094a937689eb217d1f22702e06d9e</Hash>
</Codenesium>*/