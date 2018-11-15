using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTeacherSkillMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTeacherSkillMapper();
			ApiTeacherSkillServerRequestModel model = new ApiTeacherSkillServerRequestModel();
			model.SetProperties("A");
			BOTeacherSkill response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A");
			ApiTeacherSkillServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A");
			List<ApiTeacherSkillServerResponseModel> response = mapper.MapBOToModel(new List<BOTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9ed47f4dedd8b4b20a8259e4a0558238</Hash>
</Codenesium>*/