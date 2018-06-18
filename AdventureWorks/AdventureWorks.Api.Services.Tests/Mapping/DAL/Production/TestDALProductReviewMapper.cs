using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductReviewActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductReviewMapper();

                        var bo = new BOProductReview();

                        bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        ProductReview response = mapper.MapBOToEF(bo);

                        response.Comments.Should().Be("A");
                        response.EmailAddress.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.ProductReviewID.Should().Be(1);
                        response.Rating.Should().Be(1);
                        response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ReviewerName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductReviewMapper();

                        ProductReview entity = new ProductReview();

                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOProductReview  response = mapper.MapEFToBO(entity);

                        response.Comments.Should().Be("A");
                        response.EmailAddress.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.ProductReviewID.Should().Be(1);
                        response.Rating.Should().Be(1);
                        response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ReviewerName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductReviewMapper();

                        ProductReview entity = new ProductReview();

                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOProductReview> response = mapper.MapEFToBO(new List<ProductReview>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2e18fd17b80fcf4d5668118e5af34ad9</Hash>
</Codenesium>*/