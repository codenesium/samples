using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "ApiModel")]
	public class TestApiDestinationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiDestinationServerModelMapper();
			var model = new ApiDestinationServerRequestModel();
			model.SetProperties(1, "A", 1);
			ApiDestinationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiDestinationServerModelMapper();
			var model = new ApiDestinationServerResponseModel();
			model.SetProperties(1, 1, "A", 1);
			ApiDestinationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDestinationServerModelMapper();
			var model = new ApiDestinationServerRequestModel();
			model.SetProperties(1, "A", 1);

			JsonPatchDocument<ApiDestinationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDestinationServerRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a1d6208619eca63580fc0b50b3d2833f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/