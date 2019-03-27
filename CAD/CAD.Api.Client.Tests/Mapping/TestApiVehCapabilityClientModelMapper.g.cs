using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehCapabilityModelMapper();
			var model = new ApiVehCapabilityClientRequestModel();
			model.SetProperties("A");
			ApiVehCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehCapabilityModelMapper();
			var model = new ApiVehCapabilityClientResponseModel();
			model.SetProperties(1, "A");
			ApiVehCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>6935b9dead703238cb05ae01622860c6</Hash>
</Codenesium>*/