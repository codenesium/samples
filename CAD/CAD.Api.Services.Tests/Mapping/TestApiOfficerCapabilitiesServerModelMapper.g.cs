using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilitiesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilitiesServerModelMapper();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);
			ApiOfficerCapabilitiesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilitiesServerModelMapper();
			var model = new ApiOfficerCapabilitiesServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOfficerCapabilitiesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOfficerCapabilitiesServerModelMapper();
			var model = new ApiOfficerCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOfficerCapabilitiesServerRequestModel();
			patch.ApplyTo(response);
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6b351b1901c303389d8ea77a449e3297</Hash>
</Codenesium>*/