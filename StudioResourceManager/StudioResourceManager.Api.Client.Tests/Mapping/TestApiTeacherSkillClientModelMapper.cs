using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
    <Hash>76686314206e663d01fcc1141f6c9018</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/