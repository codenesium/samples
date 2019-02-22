using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vehicle")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleServerModelMapper();
			var model = new ApiVehicleServerRequestModel();
			model.SetProperties("A");
			ApiVehicleServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleServerModelMapper();
			var model = new ApiVehicleServerResponseModel();
			model.SetProperties(1, "A");
			ApiVehicleServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleServerModelMapper();
			var model = new ApiVehicleServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiVehicleServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>90b135885e984dc0b53606d373d6aa82</Hash>
</Codenesium>*/