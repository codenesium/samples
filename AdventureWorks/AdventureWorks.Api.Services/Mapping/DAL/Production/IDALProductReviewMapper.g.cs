using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>275892a86311560895a45b65012294fa</Hash>
</Codenesium>*/