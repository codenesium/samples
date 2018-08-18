using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "ApiModel")]
	public class TestApiShoppingCartItemModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiShoppingCartItemModelMapper();
			var model = new ApiShoppingCartItemRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemResponseModel response = mapper.MapRequestToResponse(1, model);

			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
			response.ShoppingCartItemID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiShoppingCartItemModelMapper();
			var model = new ApiShoppingCartItemResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemRequestModel response = mapper.MapResponseToRequest(model);

			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiShoppingCartItemModelMapper();
			var model = new ApiShoppingCartItemRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			JsonPatchDocument<ApiShoppingCartItemRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiShoppingCartItemRequestModel();
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
    <Hash>05370bd7dadc0fa6a29ce87b908c7c47</Hash>
</Codenesium>*/