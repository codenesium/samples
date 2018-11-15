using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "ApiModel")]
	public class TestApiMachineModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiMachineModelMapper();
			var model = new ApiMachineClientRequestModel();
			model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiMachineModelMapper();
			var model = new ApiMachineClientResponseModel();
			model.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>33032097b6a43d9a9d5d8434ab36be78</Hash>
</Codenesium>*/