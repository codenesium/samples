using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilitiesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilitiesModelMapper();
			var model = new ApiOfficerCapabilitiesClientRequestModel();
			model.SetProperties(1, 1);
			ApiOfficerCapabilitiesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilitiesModelMapper();
			var model = new ApiOfficerCapabilitiesClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOfficerCapabilitiesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f2f968b52b7df59385f2cd399a1a6cc9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/