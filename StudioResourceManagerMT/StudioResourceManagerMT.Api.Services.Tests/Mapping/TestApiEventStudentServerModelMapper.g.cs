using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStudentServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1, 1);
			ApiEventStudentServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiEventStudentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiEventStudentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStudentServerRequestModel();
			patch.ApplyTo(response);
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2f53d93a4b6a664fa289e913d14b2d05</Hash>
</Codenesium>*/