using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceFeatureModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureClientRequestModel();
			model.SetProperties("A");
			ApiSpaceFeatureClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureClientResponseModel();
			model.SetProperties(1, "A");
			ApiSpaceFeatureClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>268717c3c7c6933a78112023beba9e48</Hash>
</Codenesium>*/