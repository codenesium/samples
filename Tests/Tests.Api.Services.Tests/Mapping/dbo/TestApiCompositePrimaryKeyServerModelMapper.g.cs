using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "ApiModel")]
	public class TestApiCompositePrimaryKeyServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCompositePrimaryKeyServerModelMapper();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			model.SetProperties(1);
			ApiCompositePrimaryKeyServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCompositePrimaryKeyServerModelMapper();
			var model = new ApiCompositePrimaryKeyServerResponseModel();
			model.SetProperties(1, 1);
			ApiCompositePrimaryKeyServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCompositePrimaryKeyServerModelMapper();
			var model = new ApiCompositePrimaryKeyServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCompositePrimaryKeyServerRequestModel();
			patch.ApplyTo(response);
			response.Id2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>764a5e591c51d6a7d6261f0ef770ad99</Hash>
</Codenesium>*/