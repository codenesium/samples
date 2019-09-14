using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OffCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOffCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOffCapabilityModelMapper();
			var model = new ApiOffCapabilityClientRequestModel();
			model.SetProperties("A");
			ApiOffCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOffCapabilityModelMapper();
			var model = new ApiOffCapabilityClientResponseModel();
			model.SetProperties(1, "A");
			ApiOffCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>66cd4a54af73711f3c035d2088738f5e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/