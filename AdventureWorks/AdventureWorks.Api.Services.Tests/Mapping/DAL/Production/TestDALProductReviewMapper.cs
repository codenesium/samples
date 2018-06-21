using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductReviewMapper
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

                        BOProductReview response = mapper.MapEFToBO(entity);

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
    <Hash>4ec33e10610a8d238f673e41eb0df7de</Hash>
</Codenesium>*/