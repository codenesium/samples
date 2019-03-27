using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherTeacherSkillModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillClientRequestModel();
			model.SetProperties(1);
			ApiTeacherTeacherSkillClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillClientResponseModel();
			model.SetProperties(1, 1);
			ApiTeacherTeacherSkillClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>52b0666661e84e83fe120723f372489a</Hash>
</Codenesium>*/