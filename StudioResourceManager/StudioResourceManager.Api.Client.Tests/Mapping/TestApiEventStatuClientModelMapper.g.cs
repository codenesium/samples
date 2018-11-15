using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEventStatuModelMapper();
			var model = new ApiEventStatuClientRequestModel();
			model.SetProperties("A");
			ApiEventStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventStatuModelMapper();
			var model = new ApiEventStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiEventStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c022b18d6e39563665846b6f6476dca0</Hash>
</Codenesium>*/