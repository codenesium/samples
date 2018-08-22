using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceXSpaceFeature")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceXSpaceFeatureModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSpaceXSpaceFeatureModelMapper();
			var model = new ApiSpaceXSpaceFeatureRequestModel();
			model.SetProperties(1, 1, 1);
			ApiSpaceXSpaceFeatureResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpaceXSpaceFeatureModelMapper();
			var model = new ApiSpaceXSpaceFeatureResponseModel();
			model.SetProperties(1, 1, 1, 1);
			ApiSpaceXSpaceFeatureRequestModel response = mapper.MapResponseToRequest(model);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceXSpaceFeatureModelMapper();
			var model = new ApiSpaceXSpaceFeatureRequestModel();
			model.SetProperties(1, 1, 1);

			JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceXSpaceFeatureRequestModel();
			patch.ApplyTo(response);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>47c82188b80546610b554cd0d5459244</Hash>
</Codenesium>*/