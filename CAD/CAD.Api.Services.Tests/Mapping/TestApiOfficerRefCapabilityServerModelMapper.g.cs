using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerRefCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOfficerRefCapabilityServerModelMapper();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			ApiOfficerRefCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOfficerRefCapabilityServerModelMapper();
			var model = new ApiOfficerRefCapabilityServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOfficerRefCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOfficerRefCapabilityServerModelMapper();
			var model = new ApiOfficerRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiOfficerRefCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOfficerRefCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>521667a7d433c8ed217861b662b11b66</Hash>
</Codenesium>*/