using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Unit")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUnitModelMapper();
			var model = new ApiUnitClientRequestModel();
			model.SetProperties("A");
			ApiUnitClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CallSign.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUnitModelMapper();
			var model = new ApiUnitClientResponseModel();
			model.SetProperties(1, "A");
			ApiUnitClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CallSign.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e34c6c280640a46aa15741a494b5f1c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/