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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductProductPhotoMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductProductPhotoMapper();
			ApiProductProductPhotoRequestModel model = new ApiProductProductPhotoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			BOProductProductPhoto response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductProductPhotoMapper();
			BOProductProductPhoto bo = new BOProductProductPhoto();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductProductPhotoMapper();
			BOProductProductPhoto bo = new BOProductProductPhoto();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			List<ApiProductProductPhotoResponseModel> response = mapper.MapBOToModel(new List<BOProductProductPhoto>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a184042b5e33272e808d58af6daf61ad</Hash>
</Codenesium>*/