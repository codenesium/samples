using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "ApiModel")]
	public class TestApiShoppingCartItemServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiShoppingCartItemServerModelMapper();
			var model = new ApiShoppingCartItemServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiShoppingCartItemServerModelMapper();
			var model = new ApiShoppingCartItemServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiShoppingCartItemServerModelMapper();
			var model = new ApiShoppingCartItemServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			JsonPatchDocument<ApiShoppingCartItemServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiShoppingCartItemServerRequestModel();
			patch.ApplyTo(response);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0da83e902f2ee81c6fc0ee4227e8289b</Hash>
</Codenesium>*/