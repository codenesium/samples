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
			model.SetProperties("A");
			ApiTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillResponseModel();
			model.SetProperties(1, "A");
			ApiTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTeacherSkillRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherSkillRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ab87157cd1fd84844cd2a3f5912855be</Hash>
</Codenesium>*/