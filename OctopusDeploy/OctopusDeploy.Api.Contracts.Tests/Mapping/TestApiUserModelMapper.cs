using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserRequestModel();
			model.SetProperties("A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
			ApiUserResponseModel response = mapper.MapRequestToResponse("A", model);

			response.DisplayName.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ExternalId.Should().Be("A");
			response.ExternalIdentifiers.Should().Be("A");
			response.Id.Should().Be("A");
			response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.IsActive.Should().Be(true);
			response.IsService.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserResponseModel();
			model.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
			ApiUserRequestModel response = mapper.MapResponseToRequest(model);

			response.DisplayName.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ExternalId.Should().Be("A");
			response.ExternalIdentifiers.Should().Be("A");
			response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.IsActive.Should().Be(true);
			response.IsService.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserRequestModel();
			model.SetProperties("A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");

			JsonPatchDocument<ApiUserRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserRequestModel();
			patch.ApplyTo(response);
			response.DisplayName.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ExternalId.Should().Be("A");
			response.ExternalIdentifiers.Should().Be("A");
			response.IdentificationToken.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.IsActive.Should().Be(true);
			response.IsService.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b7bd89e1a057d5897318e4f5f9c2a8d7</Hash>
</Codenesium>*/