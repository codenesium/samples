using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostTypeModelMapper();
			var model = new ApiPostTypeClientRequestModel();
			model.SetProperties("A");
			ApiPostTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostTypeModelMapper();
			var model = new ApiPostTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bfc807bc9a683bb1c286aa81edcaa21a</Hash>
</Codenesium>*/