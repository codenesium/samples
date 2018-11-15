using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "ApiModel")]
	public class TestApiAirlineModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAirlineModelMapper();
			var model = new ApiAirlineClientRequestModel();
			model.SetProperties("A");
			ApiAirlineClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAirlineModelMapper();
			var model = new ApiAirlineClientResponseModel();
			model.SetProperties(1, "A");
			ApiAirlineClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>59902f1fc3933441816b5d58821dd6f0</Hash>
</Codenesium>*/