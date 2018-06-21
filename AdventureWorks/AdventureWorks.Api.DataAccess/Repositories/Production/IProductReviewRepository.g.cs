using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductReviewRepository
        {
                Task<ProductReview> Create(ProductReview item);

                Task Update(ProductReview item);

                Task Delete(int productReviewID);

                Task<ProductReview> Get(int productReviewID);

                Task<List<ProductReview>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductReview>> ByCommentsProductIDReviewerName(string comments, int productID, string reviewerName);
        }
}

/*<Codenesium>
    <Hash>43cadd07d2223f990cf1c8c2c4852b64</Hash>
</Codenesium>*/