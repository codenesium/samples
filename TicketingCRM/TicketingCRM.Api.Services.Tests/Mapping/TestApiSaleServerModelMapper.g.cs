using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
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
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.IpAddress.Should().Be("A");
			response.Note.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerResponseModel();
			model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.IpAddress.Should().Be("A");
			response.Note.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleServerModelMapper();
			var model = new ApiSaleServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiSaleServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleServerRequestModel();
			patch.ApplyTo(response);
			response.IpAddress.Should().Be("A");
			response.Note.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>02bcdd441770152424a7c1ac1bd895dd</Hash>
</Codenesium>*/