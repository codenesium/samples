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
			model.SetProperties("A");
			ApiOfficerCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			var model = new ApiOfficerCapabilityServerResponseModel();
			model.SetProperties(1, "A");
			ApiOfficerCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOfficerCapabilityServerModelMapper();
			var model = new ApiOfficerCapabilityServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOfficerCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>08fcbe9180f49b9ebcc63a010e7bf9c3</Hash>
</Codenesium>*/