using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceSpaceFeatureServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSpaceSpaceFeatureServerModelMapper();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			model.SetProperties(1, 1);
			ApiSpaceSpaceFeatureServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSpaceSpaceFeatureServerModelMapper();
			var model = new ApiSpaceSpaceFeatureServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSpaceSpaceFeatureServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceSpaceFeatureServerModelMapper();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceSpaceFeatureServerRequestModel();
			patch.ApplyTo(response);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fd4573bd1c58ecb82e582e5e52a4c2a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/