using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleOfficerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVehicleOfficerModelMapper();
			var model = new ApiVehicleOfficerClientRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleOfficerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVehicleOfficerModelMapper();
			var model = new ApiVehicleOfficerClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleOfficerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5c04b310d2bee08aa9f0b0e0dcc30245</Hash>
</Codenesium>*/