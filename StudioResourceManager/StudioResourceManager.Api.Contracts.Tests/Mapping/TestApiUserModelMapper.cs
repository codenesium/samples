using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserRequestModel();
			model.SetProperties("A", "A");
			ApiUserResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserResponseModel();
			model.SetProperties(1, "A", "A");
			ApiUserRequestModel response = mapper.MapResponseToRequest(model);

			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiUserRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserRequestModel();
			patch.ApplyTo(response);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>67032000e5383227afdb39c691904d9c</Hash>
</Codenesium>*/