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
			model.SetProperties("A");
			ApiSubscriptionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSubscriptionModelMapper();
			var model = new ApiSubscriptionClientResponseModel();
			model.SetProperties(1, "A");
			ApiSubscriptionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8cc57079aca91df9b8a234dc595bbfb5</Hash>
</Codenesium>*/