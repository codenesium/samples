using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherTeacherSkillServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			model.SetProperties(1);
			ApiTeacherTeacherSkillServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			var model = new ApiTeacherTeacherSkillServerResponseModel();
			model.SetProperties(1, 1);
			ApiTeacherTeacherSkillServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherTeacherSkillServerRequestModel();
			patch.ApplyTo(response);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a3a1d71f287c3f6772fa8bf1a9506bd9</Hash>
</Codenesium>*/