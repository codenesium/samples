using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "ApiModel")]
	public class TestApiSaleModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleClientRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleClientResponseModel();
			model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>52035ce7e31218bfc59dfd67cb80cba6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/