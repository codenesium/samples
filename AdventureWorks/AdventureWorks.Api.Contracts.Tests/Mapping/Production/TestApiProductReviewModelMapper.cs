using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductReview")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductReviewModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductReviewModelMapper();
                        var model = new ApiProductReviewRequestModel();
                        model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiProductReviewResponseModel response = mapper.MapRequestToResponse(1, model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductReviewModelMapper();
                        var model = new ApiProductReviewResponseModel();
                        model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiProductReviewRequestModel response = mapper.MapResponseToRequest(model);

                        response.Comments.Should().Be("A");
                        response.EmailAddress.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Rating.Should().Be(1);
                        response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ReviewerName.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>8e642fbd5525a0ae2280ce016dd116a4</Hash>
</Codenesium>*/