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

                Task<List<ProductReview>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ProductReview>> GetCommentsProductIDReviewerName(string comments, int productID, string reviewerName);
        }
}

/*<Codenesium>
    <Hash>4ddf416718a590922cf490c847c5895a</Hash>
</Codenesium>*/