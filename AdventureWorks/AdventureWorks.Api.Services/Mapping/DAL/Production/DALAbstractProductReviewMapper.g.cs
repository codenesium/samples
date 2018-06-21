using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductReviewMapper
        {
                public virtual ProductReview MapBOToEF(
                        BOProductReview bo)
                {
                        ProductReview efProductReview = new ProductReview();
                        efProductReview.SetProperties(
                                bo.Comments,
                                bo.EmailAddress,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.ProductReviewID,
                                bo.Rating,
                                bo.ReviewDate,
                                bo.ReviewerName);
                        return efProductReview;
                }

                public virtual BOProductReview MapEFToBO(
                        ProductReview ef)
                {
                        var bo = new BOProductReview();

                        bo.SetProperties(
                                ef.ProductReviewID,
                                ef.Comments,
                                ef.EmailAddress,
                                ef.ModifiedDate,
                                ef.ProductID,
                                ef.Rating,
                                ef.ReviewDate,
                                ef.ReviewerName);
                        return bo;
                }

                public virtual List<BOProductReview> MapEFToBO(
                        List<ProductReview> records)
                {
                        List<BOProductReview> response = new List<BOProductReview>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>def5c2e2a0bb9052b5c92079e7d6b2b2</Hash>
</Codenesium>*/