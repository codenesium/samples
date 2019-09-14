using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
			model.SetProperties("A", "A");
			ApiUserServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerResponseModel();
			model.SetProperties(1, "A", "A");
			ApiUserServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiUserServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserServerRequestModel();
			patch.ApplyTo(response);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>849d629cf2f714f62be057f283deace0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/