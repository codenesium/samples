using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Video")]
	[Trait("Area", "ApiModel")]
	public class TestApiVideoServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVideoServerModelMapper();
			var model = new ApiVideoServerRequestModel();
			model.SetProperties("A", "A", "A");
			ApiVideoServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVideoServerModelMapper();
			var model = new ApiVideoServerResponseModel();
			model.SetProperties(1, "A", "A", "A");
			ApiVideoServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVideoServerModelMapper();
			var model = new ApiVideoServerRequestModel();
			model.SetProperties("A", "A", "A");

			JsonPatchDocument<ApiVideoServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVideoServerRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5d20749c41aa9eefd346b71aac78975c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/