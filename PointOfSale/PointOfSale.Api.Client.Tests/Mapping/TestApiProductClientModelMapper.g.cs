using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductClientRequestModel();
			model.SetProperties(true, "A", "A", 1m, 1);
			ApiProductClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductModelMapper();
			var model = new ApiProductClientResponseModel();
			model.SetProperties(1, true, "A", "A", 1m, 1);
			ApiProductClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fc5acb5397ea9631ced5f44a307c985e</Hash>
</Codenesium>*/