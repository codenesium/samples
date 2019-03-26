using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilityModelMapper();
			var model = new ApiOfficerCapabilityClientRequestModel();
			model.SetProperties(1);
			ApiOfficerCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilityModelMapper();
			var model = new ApiOfficerCapabilityClientResponseModel();
			model.SetProperties(1, 1);
			ApiOfficerCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0b12c13061fbebecf8675fc053ca7853</Hash>
</Codenesium>*/