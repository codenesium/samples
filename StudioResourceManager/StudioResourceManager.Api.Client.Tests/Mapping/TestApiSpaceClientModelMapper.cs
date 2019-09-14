using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
    <Hash>baf748b0d79bccf938634fc61e9401fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/