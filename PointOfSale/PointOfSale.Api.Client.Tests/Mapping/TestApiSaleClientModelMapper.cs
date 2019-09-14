using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Client.Tests
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
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiSaleClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleClientResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiSaleClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>087ad67526d59ac47daea9eae4e5583a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/