using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallStatusModelMapper();
			var model = new ApiCallStatusClientRequestModel();
			model.SetProperties("A");
			ApiCallStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallStatusModelMapper();
			var model = new ApiCallStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiCallStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5447c500b2543053f528e188d62edb7a</Hash>
</Codenesium>*/