using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Client.Tests
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
			model.SetProperties("A", "A", 1);
			ApiUserClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientResponseModel();
			model.SetProperties(1, "A", "A", 1);
			ApiUserClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5a3308cc22e452e354b6ca1c8cc81162</Hash>
</Codenesium>*/