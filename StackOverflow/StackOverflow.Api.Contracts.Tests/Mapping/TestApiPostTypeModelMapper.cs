using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPostTypeModelMapper();
			var model = new ApiPostTypeRequestModel();
			model.SetProperties("A");
			ApiPostTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPostTypeModelMapper();
			var model = new ApiPostTypeResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostTypeModelMapper();
			var model = new ApiPostTypeRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostTypeRequestModel();
			patch.ApplyTo(response);
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>9d21a387288491339666b41d6a36095d</Hash>
</Codenesium>*/