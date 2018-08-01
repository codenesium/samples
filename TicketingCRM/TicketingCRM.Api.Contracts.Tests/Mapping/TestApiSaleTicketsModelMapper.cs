using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketsModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSaleTicketsModelMapper();
			var model = new ApiSaleTicketsRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketsResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSaleTicketsModelMapper();
			var model = new ApiSaleTicketsResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketsRequestModel response = mapper.MapResponseToRequest(model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleTicketsModelMapper();
			var model = new ApiSaleTicketsRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSaleTicketsRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleTicketsRequestModel();
			patch.ApplyTo(response);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>adc59f54a3be1ca38c5ac25ad673a438</Hash>
</Codenesium>*/