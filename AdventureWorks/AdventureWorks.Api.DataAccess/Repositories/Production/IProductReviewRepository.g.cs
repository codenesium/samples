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
	}
}

/*<Codenesium>
    <Hash>a4ddc0b4cf5da5cc974484c56a16a66d</Hash>
</Codenesium>*/