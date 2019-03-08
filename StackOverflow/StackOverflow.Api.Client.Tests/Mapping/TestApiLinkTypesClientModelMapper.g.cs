using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkTypesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLinkTypesModelMapper();
			var model = new ApiLinkTypesClientRequestModel();
			model.SetProperties("A");
			ApiLinkTypesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLinkTypesModelMapper();
			var model = new ApiLinkTypesClientResponseModel();
			model.SetProperties(1, "A");
			ApiLinkTypesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>fc87c124efc2d3d5cd9b09329fccafe8</Hash>
</Codenesium>*/