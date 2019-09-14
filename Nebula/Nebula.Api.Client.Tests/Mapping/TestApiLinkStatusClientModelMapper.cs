using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLinkStatusModelMapper();
			var model = new ApiLinkStatusClientRequestModel();
			model.SetProperties("A");
			ApiLinkStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLinkStatusModelMapper();
			var model = new ApiLinkStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiLinkStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>46d996fd684ceba28cdc3066ccac7380</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/