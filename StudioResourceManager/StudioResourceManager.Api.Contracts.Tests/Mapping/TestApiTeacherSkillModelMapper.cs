using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherSkillModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillRequestModel();
			model.SetProperties("A", true);
			ApiTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillResponseModel();
			model.SetProperties(1, "A", true);
			ApiTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillRequestModel();
			model.SetProperties("A", true);

			JsonPatchDocument<ApiTeacherSkillRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherSkillRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>96747cb8ef9819a1775374131d181ca3</Hash>
</Codenesium>*/