using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehCapabilityServerModelMapper();
			var model = new ApiVehCapabilityServerRequestModel();
			model.SetProperties("A");
			ApiVehCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehCapabilityServerModelMapper();
			var model = new ApiVehCapabilityServerResponseModel();
			model.SetProperties(1, "A");
			ApiVehCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehCapabilityServerModelMapper();
			var model = new ApiVehCapabilityServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVehCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>6292d849764a9e0da2f70cb25a052443</Hash>
</Codenesium>*/