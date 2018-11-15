using AdventureWorksNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductReviewMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductReviewMapper();
			ApiProductReviewServerRequestModel model = new ApiProductReviewServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOProductReview response = mapper.MapModelToBO(1, model);

			response.Comment.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Rating.Should().Be(1);
			response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReviewerName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductReviewMapper();
			BOProductReview bo = new BOProductReview();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewServerResponseModel response = mapper.MapBOToModel(bo);

			response.Comment.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.ProductReviewID.Should().Be(1);
			response.Rating.Should().Be(1);
			response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReviewerName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductReviewMapper();
			BOProductReview bo = new BOProductReview();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiProductReviewServerResponseModel> response = mapper.MapBOToModel(new List<BOProductReview>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2fbbc4a3508b6605753abb90ee720d8f</Hash>
</Codenesium>*/