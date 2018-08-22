using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
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
			model.SetProperties("A", "A", 1);
			ApiSpaceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceResponseModel();
			model.SetProperties(1, "A", "A", 1);
			ApiSpaceRequestModel response = mapper.MapResponseToRequest(model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceModelMapper();
			var model = new ApiSpaceRequestModel();
			model.SetProperties("A", "A", 1);

			JsonPatchDocument<ApiSpaceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8aa23f7c711a2aa127368863a6267a77</Hash>
</Codenesium>*/