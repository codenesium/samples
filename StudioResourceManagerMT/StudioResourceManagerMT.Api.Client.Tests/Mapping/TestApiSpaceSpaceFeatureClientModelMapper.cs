using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceSpaceFeatureModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureClientRequestModel();
			model.SetProperties(1, 1);
			ApiSpaceSpaceFeatureClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSpaceSpaceFeatureClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ce508f0f8047c8d9a5556850a2945ca0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/