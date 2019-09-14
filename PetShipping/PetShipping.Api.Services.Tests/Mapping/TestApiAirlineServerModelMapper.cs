using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "ApiModel")]
	public class TestApiAirlineServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiAirlineServerModelMapper();
			var model = new ApiAirlineServerRequestModel();
			model.SetProperties("A");
			ApiAirlineServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAirlineServerModelMapper();
			var model = new ApiAirlineServerResponseModel();
			model.SetProperties(1, "A");
			ApiAirlineServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAirlineServerModelMapper();
			var model = new ApiAirlineServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiAirlineServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAirlineServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>89d2a88cc8da86b2fa04cab5c3fb0e60</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/