using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A", "A", 1);
			ApiUserServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerResponseModel();
			model.SetProperties(1, "A", "A", "A", 1);
			ApiUserServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A", "A", 1);

			JsonPatchDocument<ApiUserServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserServerRequestModel();
			patch.ApplyTo(response);
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>69024e2282cc57f32b7bc88837feb55b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/