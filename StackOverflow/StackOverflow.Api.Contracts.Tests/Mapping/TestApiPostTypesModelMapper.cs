using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPostTypesModelMapper();
			var model = new ApiPostTypesRequestModel();
			model.SetProperties("A");
			ApiPostTypesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPostTypesModelMapper();
			var model = new ApiPostTypesResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypesRequestModel response = mapper.MapResponseToRequest(model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostTypesModelMapper();
			var model = new ApiPostTypesRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostTypesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostTypesRequestModel();
			patch.ApplyTo(response);
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>88d0fbe66278ae77d27debbab4c69d66</Hash>
</Codenesium>*/