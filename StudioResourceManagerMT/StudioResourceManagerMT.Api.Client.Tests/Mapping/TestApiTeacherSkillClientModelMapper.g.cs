using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeacherSkillModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillClientRequestModel();
			model.SetProperties("A");
			ApiTeacherSkillClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTeacherSkillModelMapper();
			var model = new ApiTeacherSkillClientResponseModel();
			model.SetProperties(1, "A");
			ApiTeacherSkillClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>782cb0374b241e0e2c2f324a10df2a66</Hash>
</Codenesium>*/