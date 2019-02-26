using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "ApiModel")]
	public class TestApiSubscriptionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSubscriptionServerModelMapper();
			var model = new ApiSubscriptionServerRequestModel();
			model.SetProperties("A");
			ApiSubscriptionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSubscriptionServerModelMapper();
			var model = new ApiSubscriptionServerResponseModel();
			model.SetProperties(1, "A");
			ApiSubscriptionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSubscriptionServerModelMapper();
			var model = new ApiSubscriptionServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSubscriptionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSubscriptionServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>73e2a66840ed23ebd363718e9badad53</Hash>
</Codenesium>*/