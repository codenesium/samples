using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerRequestModel();
			model.SetProperties("A");
			ApiCountryServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerResponseModel();
			model.SetProperties(1, "A");
			ApiCountryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCountryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCountryServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>9515b3d5af8393bdd5f2a9815c8831fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/