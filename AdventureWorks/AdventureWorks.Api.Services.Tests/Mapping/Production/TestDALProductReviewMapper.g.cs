using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductReview")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductReviewMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALProductReviewMapper();
			ApiProductReviewServerRequestModel model = new ApiProductReviewServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ProductReview response = mapper.MapModelToEntity(1, model);

			response.Comment.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Rating.Should().Be(1);
			response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReviewerName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALProductReviewMapper();
			ProductReview item = new ProductReview();
			item.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiProductReviewServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALProductReviewMapper();
			ProductReview item = new ProductReview();
			item.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiProductReviewServerResponseModel> response = mapper.MapEntityToModel(new List<ProductReview>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>853acfd349cc8b2e4d51d1926eecd7ff</Hash>
</Codenesium>*/