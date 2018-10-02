using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceRequestModel();
			model.SetProperties("A", "A");
			ApiSpaceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceResponseModel();
			model.SetProperties(1, "A", "A");
			ApiSpaceRequestModel response = mapper.MapResponseToRequest(model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiSpaceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a25410e16687c597b44890d03bcdb156</Hash>
</Codenesium>*/