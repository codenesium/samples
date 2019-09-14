using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
			model.SetProperties(1, 1);
			ApiTeacherTeacherSkillClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTeacherTeacherSkillModelMapper();
			var model = new ApiTeacherTeacherSkillClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiTeacherTeacherSkillClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d1cd1ee63155b11719969a6d8781c4d1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/