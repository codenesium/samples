using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceSpaceFeatureModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1, 1);
			ApiSpaceSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSpaceSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceSpaceFeatureRequestModel();
			patch.ApplyTo(response);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2ddbdd21aa956165cb7523faad74c0f2</Hash>
</Codenesium>*/