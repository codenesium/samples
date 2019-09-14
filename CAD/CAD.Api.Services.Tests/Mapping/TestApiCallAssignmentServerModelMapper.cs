using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallAssignment")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallAssignmentServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallAssignmentServerModelMapper();
			var model = new ApiCallAssignmentServerRequestModel();
			model.SetProperties(1, 1);
			ApiCallAssignmentServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallAssignmentServerModelMapper();
			var model = new ApiCallAssignmentServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiCallAssignmentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallAssignmentServerModelMapper();
			var model = new ApiCallAssignmentServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiCallAssignmentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallAssignmentServerRequestModel();
			patch.ApplyTo(response);
			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7a2b6ec70fcbe864d0509637095958a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/