using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStudentModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentClientRequestModel();
			model.SetProperties(1);
			ApiEventStudentClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentClientResponseModel();
			model.SetProperties(1, 1);
			ApiEventStudentClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ba775497443ca20a5c63c470830ff7d</Hash>
</Codenesium>*/