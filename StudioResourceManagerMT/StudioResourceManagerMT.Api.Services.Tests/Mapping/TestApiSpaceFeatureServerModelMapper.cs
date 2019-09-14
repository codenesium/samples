using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
    <Hash>26dc2dc43d900093a578c7fdecb90367</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/