using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitOfficerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiUnitOfficerServerModelMapper();
			var model = new ApiUnitOfficerServerRequestModel();
			model.SetProperties(1, 1);
			ApiUnitOfficerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUnitOfficerServerModelMapper();
			var model = new ApiUnitOfficerServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiUnitOfficerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUnitOfficerServerModelMapper();
			var model = new ApiUnitOfficerServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiUnitOfficerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUnitOfficerServerRequestModel();
			patch.ApplyTo(response);
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>72f636dc4b2fa208530f87871456bcfd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/