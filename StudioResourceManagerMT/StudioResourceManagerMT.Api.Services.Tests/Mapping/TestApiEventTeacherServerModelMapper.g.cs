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
			model.SetProperties(1);
			ApiEventTeacherServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventTeacherServerModelMapper();
			var model = new ApiEventTeacherServerResponseModel();
			model.SetProperties(1, 1);
			ApiEventTeacherServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventTeacherServerModelMapper();
			var model = new ApiEventTeacherServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiEventTeacherServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventTeacherServerRequestModel();
			patch.ApplyTo(response);
			response.TeacherId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bf0993d97900552872444a1c9362c0a9</Hash>
</Codenesium>*/