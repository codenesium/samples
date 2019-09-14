using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "ApiModel")]
	public class TestApiDestinationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiDestinationModelMapper();
			var model = new ApiDestinationClientRequestModel();
			model.SetProperties(1, "A", 1);
			ApiDestinationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiDestinationModelMapper();
			var model = new ApiDestinationClientResponseModel();
			model.SetProperties(1, 1, "A", 1);
			ApiDestinationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>13519d5e2840f66226db5bb5b8f13e75</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/