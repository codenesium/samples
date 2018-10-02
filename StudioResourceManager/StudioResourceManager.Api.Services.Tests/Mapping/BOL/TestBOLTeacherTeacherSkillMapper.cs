using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTeacherTeacherSkillMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTeacherTeacherSkillMapper();
			ApiTeacherTeacherSkillRequestModel model = new ApiTeacherTeacherSkillRequestModel();
			model.SetProperties(1, 1);
			BOTeacherTeacherSkill response = mapper.MapModelToBO(1, model);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherTeacherSkillMapper();
			BOTeacherTeacherSkill bo = new BOTeacherTeacherSkill();
			bo.SetProperties(1, 1, 1);
			ApiTeacherTeacherSkillResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherTeacherSkillMapper();
			BOTeacherTeacherSkill bo = new BOTeacherTeacherSkill();
			bo.SetProperties(1, 1, 1);
			List<ApiTeacherTeacherSkillResponseModel> response = mapper.MapBOToModel(new List<BOTeacherTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>13b75d79718dffa6cd5212f611f341e3</Hash>
</Codenesium>*/