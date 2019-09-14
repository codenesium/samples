using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
    <Hash>559f88759ef2e6bf32ac03dd3939bf6f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/