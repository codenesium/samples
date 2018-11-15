using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientRequestModel();
			model.SetProperties("A", "A");
			ApiUserClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientResponseModel();
			model.SetProperties(1, "A", "A");
			ApiUserClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>77364f06d1eeceb5a68be52abfd9a6d0</Hash>
</Codenesium>*/