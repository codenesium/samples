using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallStatuModelMapper();
			var model = new ApiCallStatuClientRequestModel();
			model.SetProperties("A");
			ApiCallStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallStatuModelMapper();
			var model = new ApiCallStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiCallStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>83a94865ceb6eb93f6cd9831ca4b40d7</Hash>
</Codenesium>*/