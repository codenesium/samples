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
			model.SetProperties(1, 1);
			ApiTeacherTeacherSkillServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			var model = new ApiTeacherTeacherSkillServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiTeacherTeacherSkillServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherTeacherSkillServerModelMapper();
			var model = new ApiTeacherTeacherSkillServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherTeacherSkillServerRequestModel();
			patch.ApplyTo(response);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e59bc9e1373b8e66bd36799493f4f853</Hash>
</Codenesium>*/