using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
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
			model.SetProperties("A", 1);
			ApiSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureResponseModel();
			model.SetProperties(1, "A", 1);
			ApiSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceFeatureModelMapper();
			var model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiSpaceFeatureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceFeatureRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d60283191b872f33e8994204ff2a6906</Hash>
</Codenesium>*/