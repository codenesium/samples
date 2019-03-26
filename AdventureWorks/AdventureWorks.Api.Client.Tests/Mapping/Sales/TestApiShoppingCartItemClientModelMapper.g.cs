using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "ApiModel")]
	public class TestApiShoppingCartItemModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiShoppingCartItemModelMapper();
			var model = new ApiShoppingCartItemClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiShoppingCartItemModelMapper();
			var model = new ApiShoppingCartItemClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>653a190eb0ef895fc85d1658c5e008a7</Hash>
</Codenesium>*/