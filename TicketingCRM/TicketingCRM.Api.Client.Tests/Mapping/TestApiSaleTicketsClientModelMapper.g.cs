using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketsModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSaleTicketsModelMapper();
			var model = new ApiSaleTicketsClientRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketsClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleTicketsModelMapper();
			var model = new ApiSaleTicketsClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketsClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>320756eaf439751df7d155eef5963788</Hash>
</Codenesium>*/