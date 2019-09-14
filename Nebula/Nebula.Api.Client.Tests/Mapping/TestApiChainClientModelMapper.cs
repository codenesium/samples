using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Chain")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiChainModelMapper();
			var model = new ApiChainClientRequestModel();
			model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiChainModelMapper();
			var model = new ApiChainClientResponseModel();
			model.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiChainClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ChainStatusId.Should().Be(1);
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
			response.TeamId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>abe7e19fb15953609f9c701c37cd1d46</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/