using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachineServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiMachineServerModelMapper();
			var model = new ApiMachineServerRequestModel();
			model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiMachineServerModelMapper();
			var model = new ApiMachineServerResponseModel();
			model.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMachineServerModelMapper();
			var model = new ApiMachineServerRequestModel();
			model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

			JsonPatchDocument<ApiMachineServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMachineServerRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>540871e2fbc4a8480d34319e0e194a69</Hash>
</Codenesium>*/