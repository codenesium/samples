using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Chain")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiChainServerModelMapper();
			var model = new ApiChainServerRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiChainServerModelMapper();
			var model = new ApiChainServerResponseModel();
			model.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiChainServerModelMapper();
			var model = new ApiChainServerRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);

			JsonPatchDocument<ApiChainServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiChainServerRequestModel();
			patch.ApplyTo(response);
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>693acbaa62ab5405803eede43dd2ddb3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/