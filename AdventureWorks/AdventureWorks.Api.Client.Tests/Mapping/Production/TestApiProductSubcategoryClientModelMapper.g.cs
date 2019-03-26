using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductSubcategoryModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductSubcategoryModelMapper();
			var model = new ApiProductSubcategoryClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductSubcategoryClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductSubcategoryModelMapper();
			var model = new ApiProductSubcategoryClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductSubcategoryClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ProductCategoryID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>55f47714fca78778b1d381dcd9458ef2</Hash>
</Codenesium>*/