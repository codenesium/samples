using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
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
			model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleClientResponseModel();
			model.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
    <Hash>ddfcfd93cd599ecd7ab85c1031e93204</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/