using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallAssignment")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallAssignmentModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallAssignmentModelMapper();
			var model = new ApiCallAssignmentClientRequestModel();
			model.SetProperties(1, 1);
			ApiCallAssignmentClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallAssignmentModelMapper();
			var model = new ApiCallAssignmentClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiCallAssignmentClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>653a993eca3ff396d191a9f458b47803</Hash>
</Codenesium>*/