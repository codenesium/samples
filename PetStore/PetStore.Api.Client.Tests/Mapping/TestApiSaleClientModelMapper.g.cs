using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
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
			model.SetProperties(1m, "A", "A", 1, 1, "A");
			ApiSaleClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSaleModelMapper();
			var model = new ApiSaleClientResponseModel();
			model.SetProperties(1, 1m, "A", "A", 1, 1, "A");
			ApiSaleClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e95705530bcac65fdf506a25e59c06ea</Hash>
</Codenesium>*/