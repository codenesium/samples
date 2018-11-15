using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductReview")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductReviewServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProductReviewServerModelMapper();
			var model = new ApiProductReviewServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProductReviewServerModelMapper();
			var model = new ApiProductReviewServerResponseModel();
			model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiProductReviewServerModelMapper();
			var model = new ApiProductReviewServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiProductReviewServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductReviewServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>501b05da1135e3e0c3055e833ff570b3</Hash>
</Codenesium>*/