using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiChainStatusModelMapper();
			var model = new ApiChainStatusClientRequestModel();
			model.SetProperties("A");
			ApiChainStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiChainStatusModelMapper();
			var model = new ApiChainStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiChainStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8500dea9541cfa95a790b862dacd3e31</Hash>
</Codenesium>*/