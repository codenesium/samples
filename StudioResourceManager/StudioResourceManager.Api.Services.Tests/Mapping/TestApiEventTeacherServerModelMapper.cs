using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
    <Hash>737c541c607c8b0bb69fff14d7d489f5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/