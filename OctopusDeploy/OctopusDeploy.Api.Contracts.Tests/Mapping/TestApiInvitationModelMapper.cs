using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Invitation")]
	[Trait("Area", "ApiModel")]
	public class TestApiInvitationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiInvitationModelMapper();
			var model = new ApiInvitationRequestModel();
			model.SetProperties("A", "A");
			ApiInvitationResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.InvitationCode.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiInvitationModelMapper();
			var model = new ApiInvitationResponseModel();
			model.SetProperties("A", "A", "A");
			ApiInvitationRequestModel response = mapper.MapResponseToRequest(model);

			response.InvitationCode.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiInvitationModelMapper();
			var model = new ApiInvitationRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiInvitationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiInvitationRequestModel();
			patch.ApplyTo(response);
			response.InvitationCode.Should().Be("A");
			response.JSON.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f67a15cdcf9eb02ce06e07fed421a1a0</Hash>
</Codenesium>*/