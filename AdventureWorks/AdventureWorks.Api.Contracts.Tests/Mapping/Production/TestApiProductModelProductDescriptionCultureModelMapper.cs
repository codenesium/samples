using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModelProductDescriptionCulture")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductModelProductDescriptionCultureModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProductModelProductDescriptionCultureModelMapper();
			var model = new ApiProductModelProductDescriptionCultureRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiProductModelProductDescriptionCultureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.ProductModelID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProductModelProductDescriptionCultureModelMapper();
			var model = new ApiProductModelProductDescriptionCultureResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiProductModelProductDescriptionCultureRequestModel response = mapper.MapResponseToRequest(model);

			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductModelProductDescriptionCultureModelMapper();
			var model = new ApiProductModelProductDescriptionCultureRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductModelProductDescriptionCultureRequestModel();
			patch.ApplyTo(response);
			response.CultureID.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d8797ce6ae6e40b1e3f95579b6d7a6c9</Hash>
</Codenesium>*/