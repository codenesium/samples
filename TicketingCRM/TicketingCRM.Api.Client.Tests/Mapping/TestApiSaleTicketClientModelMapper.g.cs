using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSaleTicketModelMapper();
			var model = new ApiSaleTicketClientRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleTicketModelMapper();
			var model = new ApiSaleTicketClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ae285bf6d39473c097b9e135f877e795</Hash>
</Codenesium>*/