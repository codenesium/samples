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
			model.SetProperties(1, true);
			ApiSpaceSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureResponseModel();
			model.SetProperties(1, 1, true);
			ApiSpaceSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

			response.SpaceFeatureId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceSpaceFeatureModelMapper();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1, true);

			JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceSpaceFeatureRequestModel();
			patch.ApplyTo(response);
			response.SpaceFeatureId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>22b26548eb05de2f4d61f68213abeb29</Hash>
</Codenesium>*/