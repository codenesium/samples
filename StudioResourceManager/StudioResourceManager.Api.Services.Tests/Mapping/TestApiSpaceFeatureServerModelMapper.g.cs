using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceFeatureServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSpaceFeatureServerModelMapper();
			var model = new ApiSpaceFeatureServerRequestModel();
			model.SetProperties("A");
			ApiSpaceFeatureServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSpaceFeatureServerModelMapper();
			var model = new ApiSpaceFeatureServerResponseModel();
			model.SetProperties(1, "A");
			ApiSpaceFeatureServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceFeatureServerModelMapper();
			var model = new ApiSpaceFeatureServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSpaceFeatureServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceFeatureServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0c78ed9a9e0ce96f5bfc0c7e1a99fd9b</Hash>
</Codenesium>*/