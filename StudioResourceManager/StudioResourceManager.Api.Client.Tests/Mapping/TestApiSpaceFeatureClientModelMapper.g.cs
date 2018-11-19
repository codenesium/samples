using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
    <Hash>db6c9aeb36ef1d08fb7fba31d2bbd842</Hash>
</Codenesium>*/