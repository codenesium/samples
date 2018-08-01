using ESPIOTNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Device")]
	[Trait("Area", "ApiModel")]
	public class TestApiDeviceModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceResponseModel();
			model.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiDeviceRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDeviceModelMapper();
			var model = new ApiDeviceRequestModel();
			model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiDeviceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDeviceRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>7fa158374f963597d79a6926be32a160</Hash>
</Codenesium>*/