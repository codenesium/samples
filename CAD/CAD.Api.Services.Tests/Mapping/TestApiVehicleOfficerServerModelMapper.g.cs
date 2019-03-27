using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleOfficer")]
	[Trait("Area", "ApiModel")]
	public class TestApiVehicleOfficerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVehicleOfficerServerModelMapper();
			var model = new ApiVehicleOfficerServerRequestModel();
			model.SetProperties(1, 1);
			ApiVehicleOfficerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVehicleOfficerServerModelMapper();
			var model = new ApiVehicleOfficerServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiVehicleOfficerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVehicleOfficerServerModelMapper();
			var model = new ApiVehicleOfficerServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiVehicleOfficerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVehicleOfficerServerRequestModel();
			patch.ApplyTo(response);
			response.OfficerId.Should().Be(1);
			response.VehicleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cff33d6cbb560c302f90cab15cf59ff0</Hash>
</Codenesium>*/