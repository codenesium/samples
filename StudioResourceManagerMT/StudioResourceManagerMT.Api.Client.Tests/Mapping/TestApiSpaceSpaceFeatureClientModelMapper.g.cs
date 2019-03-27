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
			model.SetProperties(1);
			ApiSpaceSpaceFeatureClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureClientResponseModel();
			model.SetProperties(1, 1);
			ApiSpaceSpaceFeatureClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>684a689ba5fd8549e8f21fa9afd79e62</Hash>
</Codenesium>*/