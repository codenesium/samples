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
			model.SetProperties("A", "A", true);
			ApiSpaceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceResponseModel();
			model.SetProperties(1, "A", "A", true);
			ApiSpaceRequestModel response = mapper.MapResponseToRequest(model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceRequestModel();
			model.SetProperties("A", "A", true);

			JsonPatchDocument<ApiSpaceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>739f76d4f597678eb57d3a18c829c82d</Hash>
</Codenesium>*/