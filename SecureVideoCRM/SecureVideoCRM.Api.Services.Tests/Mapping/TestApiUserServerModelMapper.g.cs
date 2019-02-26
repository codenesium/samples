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
			model.SetProperties("A", "A", 1);
			ApiUserServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerResponseModel();
			model.SetProperties(1, "A", "A", 1);
			ApiUserServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A", 1);

			JsonPatchDocument<ApiUserServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserServerRequestModel();
			patch.ApplyTo(response);
			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7f98efe0e6420f27d42de48fe3c36cb3</Hash>
</Codenesium>*/