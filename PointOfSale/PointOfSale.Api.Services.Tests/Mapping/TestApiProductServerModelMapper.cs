using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Product")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProductServerModelMapper();
			var model = new ApiProductServerRequestModel();
			model.SetProperties(true, "A", "A", 1m, 1);
			ApiProductServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProductServerModelMapper();
			var model = new ApiProductServerResponseModel();
			model.SetProperties(1, true, "A", "A", 1m, 1);
			ApiProductServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductServerModelMapper();
			var model = new ApiProductServerRequestModel();
			model.SetProperties(true, "A", "A", 1m, 1);

			JsonPatchDocument<ApiProductServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductServerRequestModel();
			patch.ApplyTo(response);
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5b77db011f97279cbdb367198f85d94f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/