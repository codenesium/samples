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
			model.SetProperties("A", "A", "A", 1);
			ApiUserClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientResponseModel();
			model.SetProperties(1, "A", "A", "A", 1);
			ApiUserClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e12a36db3dc3036ea880e159b3f90393</Hash>
</Codenesium>*/