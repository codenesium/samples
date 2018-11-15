using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductReview")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductReviewModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductReviewModelMapper();
			var model = new ApiProductReviewClientRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Rating.Should().Be(1);
			response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReviewerName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductReviewModelMapper();
			var model = new ApiProductReviewClientResponseModel();
			model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
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
    <Hash>458de550ac1a13b1c547a14e2fba4871</Hash>
</Codenesium>*/