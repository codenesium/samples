using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			var model = new ApiOfficerCapabilityServerRequestModel();
			model.SetProperties(1);
			ApiOfficerCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			var model = new ApiOfficerCapabilityServerResponseModel();
			model.SetProperties(1, 1);
			ApiOfficerCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			var model = new ApiOfficerCapabilityServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOfficerCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d2c2189fe49e454daa6a90b9b0525bf6</Hash>
</Codenesium>*/