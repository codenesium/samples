using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSaleTicketModelMapper();
			var model = new ApiSaleTicketRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSaleTicketModelMapper();
			var model = new ApiSaleTicketResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketRequestModel response = mapper.MapResponseToRequest(model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleTicketModelMapper();
			var model = new ApiSaleTicketRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSaleTicketRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleTicketRequestModel();
			patch.ApplyTo(response);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>74172b88dee67a7e3b554d79ede192ac</Hash>
</Codenesium>*/