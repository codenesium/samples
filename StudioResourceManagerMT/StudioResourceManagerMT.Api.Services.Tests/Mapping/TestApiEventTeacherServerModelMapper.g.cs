using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventTeacherServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventTeacherServerModelMapper();
			var model = new ApiEventTeacherServerRequestModel();
			model.SetProperties(1, 1);
			ApiEventTeacherServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventTeacherServerModelMapper();
			var model = new ApiEventTeacherServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiEventTeacherServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventTeacherServerModelMapper();
			var model = new ApiEventTeacherServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiEventTeacherServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventTeacherServerRequestModel();
			patch.ApplyTo(response);
			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>db9be64c73c41fc93707fdf68820df72</Hash>
</Codenesium>*/