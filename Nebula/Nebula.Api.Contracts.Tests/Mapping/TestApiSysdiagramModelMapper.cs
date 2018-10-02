using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "ApiModel")]
	public class TestApiSysdiagramModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSysdiagramModelMapper();
			var model = new ApiSysdiagramRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", 1, 1);
			ApiSysdiagramResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DiagramId.Should().Be(1);
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSysdiagramModelMapper();
			var model = new ApiSysdiagramResponseModel();
			model.SetProperties(1, BitConverter.GetBytes(1), "A", 1, 1);
			ApiSysdiagramRequestModel response = mapper.MapResponseToRequest(model);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSysdiagramModelMapper();
			var model = new ApiSysdiagramRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", 1, 1);

			JsonPatchDocument<ApiSysdiagramRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSysdiagramRequestModel();
			patch.ApplyTo(response);
			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f82a564c02453e85f7d4f1bd77f06760</Hash>
</Codenesium>*/