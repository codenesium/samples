using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerResponseModel();
			model.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiSaleServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleServerRequestModel();
			patch.ApplyTo(response);
			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5e0039c8446c9e1667dc65db60de47fc</Hash>
</Codenesium>*/