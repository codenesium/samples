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

                Task<List<ProductReview>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductReview>> ByCommentsProductIDReviewerName(string comments, int productID, string reviewerName);
        }
}

/*<Codenesium>
    <Hash>2ce14439806f93ce079b4a730233aa17</Hash>
</Codenesium>*/