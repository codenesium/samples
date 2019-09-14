using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "ApiModel")]
	public class TestApiSubscriptionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSubscriptionModelMapper();
			var model = new ApiSubscriptionClientRequestModel();
			model.SetProperties("A", "A");
			ApiSubscriptionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.StripePlanName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSubscriptionModelMapper();
			var model = new ApiSubscriptionClientResponseModel();
			model.SetProperties(1, "A", "A");
			ApiSubscriptionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.StripePlanName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>69483b7459328a0e4b5b105c498fde52</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/