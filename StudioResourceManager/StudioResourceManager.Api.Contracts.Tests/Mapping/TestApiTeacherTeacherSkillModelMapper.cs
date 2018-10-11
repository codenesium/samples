using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherTeacherSkillModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1);
			ApiTeacherTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillResponseModel();
			model.SetProperties(1, 1);
			ApiTeacherTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherTeacherSkillRequestModel();
			patch.ApplyTo(response);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ec2de3eeb076ff98a3e0e76538805b6c</Hash>
</Codenesium>*/