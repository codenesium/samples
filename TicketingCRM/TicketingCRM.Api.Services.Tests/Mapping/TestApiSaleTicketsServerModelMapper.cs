using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleTicketsServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSaleTicketsServerModelMapper();
			var model = new ApiSaleTicketsServerRequestModel();
			model.SetProperties(1, 1);
			ApiSaleTicketsServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSaleTicketsServerModelMapper();
			var model = new ApiSaleTicketsServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSaleTicketsServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSaleTicketsServerModelMapper();
			var model = new ApiSaleTicketsServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSaleTicketsServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSaleTicketsServerRequestModel();
			patch.ApplyTo(response);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fe0ff8058f5daf477f8be5d6f04e3664</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/