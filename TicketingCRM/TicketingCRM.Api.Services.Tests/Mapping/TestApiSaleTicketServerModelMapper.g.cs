using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSaleTicketServerModelMapper();
			var model = new ApiSaleTicketServerRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSaleTicketServerModelMapper();
			var model = new ApiSaleTicketServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleTicketServerModelMapper();
			var model = new ApiSaleTicketServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSaleTicketServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleTicketServerRequestModel();
			patch.ApplyTo(response);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ddf4b5c7ccca90297defc1fdef9f68ce</Hash>
</Codenesium>*/