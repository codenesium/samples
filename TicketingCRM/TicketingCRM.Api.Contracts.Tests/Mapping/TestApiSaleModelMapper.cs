using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleResponseModel();
			model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleRequestModel response = mapper.MapResponseToRequest(model);

			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiSaleRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleRequestModel();
			patch.ApplyTo(response);
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d06ac35c4a663b34a78869f97fa87870</Hash>
</Codenesium>*/