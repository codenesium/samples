using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherSkillServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTeacherSkillServerModelMapper();
			var model = new ApiTeacherSkillServerRequestModel();
			model.SetProperties("A");
			ApiTeacherSkillServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTeacherSkillServerModelMapper();
			var model = new ApiTeacherSkillServerResponseModel();
			model.SetProperties(1, "A");
			ApiTeacherSkillServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTeacherSkillServerModelMapper();
			var model = new ApiTeacherSkillServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTeacherSkillServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTeacherSkillServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a05c88d775fdde5df7c27ad22d77c37d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/