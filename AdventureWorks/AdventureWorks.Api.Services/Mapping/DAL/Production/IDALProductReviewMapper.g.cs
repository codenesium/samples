using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductReviewMapper
        {
                ProductReview MapBOToEF(
                        BOProductReview bo);

                BOProductReview MapEFToBO(
                        ProductReview efProductReview);

                List<BOProductReview> MapEFToBO(
                        List<ProductReview> records);
        }
}

/*<Codenesium>
    <Hash>cac6518869580df2a72e75c269a603c8</Hash>
</Codenesium>*/