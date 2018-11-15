using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "ApiModel")]
	public class TestApiCityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCityModelMapper();
			var model = new ApiCityClientRequestModel();
			model.SetProperties("A", 1);
			ApiCityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCityModelMapper();
			var model = new ApiCityClientResponseModel();
			model.SetProperties(1, "A", 1);
			ApiCityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>48f39a7ce9a10f4fc207c3f4be63c740</Hash>
</Codenesium>*/