using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceClientRequestModel();
			model.SetProperties("A", "A");
			ApiSpaceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceClientResponseModel();
			model.SetProperties(1, "A", "A");
			ApiSpaceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>823033dcff84e65e2177572bf253c17b</Hash>
</Codenesium>*/