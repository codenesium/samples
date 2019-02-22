using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerRefCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerRefCapabilityModelMapper();
			var model = new ApiOfficerRefCapabilityClientRequestModel();
			model.SetProperties(1, 1);
			ApiOfficerRefCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerRefCapabilityModelMapper();
			var model = new ApiOfficerRefCapabilityClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOfficerRefCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1ac5d8e9105345c1a36c7fe920984960</Hash>
</Codenesium>*/