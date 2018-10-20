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
			model.SetProperties(1, true);
			ApiTeacherTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillResponseModel();
			model.SetProperties(1, 1, true);
			ApiTeacherTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1, true);

			JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherTeacherSkillRequestModel();
			patch.ApplyTo(response);
			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>c0081331d2c5633d825cf0a0c5b2ee9a</Hash>
</Codenesium>*/