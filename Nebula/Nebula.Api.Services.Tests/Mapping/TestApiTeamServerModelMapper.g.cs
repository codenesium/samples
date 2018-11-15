using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeamServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTeamServerModelMapper();
			var model = new ApiTeamServerRequestModel();
			model.SetProperties("A", 1);
			ApiTeamServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTeamServerModelMapper();
			var model = new ApiTeamServerResponseModel();
			model.SetProperties(1, "A", 1);
			ApiTeamServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeamServerModelMapper();
			var model = new ApiTeamServerRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiTeamServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeamServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2e4574e186d131c7e710da29b0d3ce1a</Hash>
</Codenesium>*/