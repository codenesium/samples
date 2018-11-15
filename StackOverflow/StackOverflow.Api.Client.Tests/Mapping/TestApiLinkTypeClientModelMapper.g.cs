using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLinkTypeModelMapper();
			var model = new ApiLinkTypeClientRequestModel();
			model.SetProperties("A");
			ApiLinkTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLinkTypeModelMapper();
			var model = new ApiLinkTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiLinkTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b22544a2dc70d6c27f973fe23d2aaa83</Hash>
</Codenesium>*/