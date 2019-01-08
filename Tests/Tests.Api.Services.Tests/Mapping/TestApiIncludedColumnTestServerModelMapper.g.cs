using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "ApiModel")]
	public class TestApiIncludedColumnTestServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiIncludedColumnTestServerModelMapper();
			var model = new ApiIncludedColumnTestServerRequestModel();
			model.SetProperties("A", "A");
			ApiIncludedColumnTestServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiIncludedColumnTestServerModelMapper();
			var model = new ApiIncludedColumnTestServerResponseModel();
			model.SetProperties(1, "A", "A");
			ApiIncludedColumnTestServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiIncludedColumnTestServerModelMapper();
			var model = new ApiIncludedColumnTestServerRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiIncludedColumnTestServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiIncludedColumnTestServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c217cecf25f7255e19860306815992d8</Hash>
</Codenesium>*/