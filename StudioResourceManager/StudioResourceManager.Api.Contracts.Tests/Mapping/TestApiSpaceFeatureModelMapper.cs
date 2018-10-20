using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceFeatureModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("A", true);
			ApiSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureResponseModel();
			model.SetProperties(1, "A", true);
			ApiSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("A", true);

			JsonPatchDocument<ApiSpaceFeatureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceFeatureRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>e086f4d8c8298610cbb5d839c23d31c4</Hash>
</Codenesium>*/