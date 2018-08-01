using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Chain")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiChainModelMapper();
			var model = new ApiChainRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiChainModelMapper();
			var model = new ApiChainResponseModel();
			model.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainRequestModel response = mapper.MapResponseToRequest(model);

			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiChainModelMapper();
			var model = new ApiChainRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);

			JsonPatchDocument<ApiChainRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiChainRequestModel();
			patch.ApplyTo(response);
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a07792e20003c4917aed48d5a2546927</Hash>
</Codenesium>*/