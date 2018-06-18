using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>29606a0c2a2c817cd78e40cdc81e2ebe</Hash>
</Codenesium>*/