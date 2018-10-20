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
			model.SetProperties(1, true);
			BOTeacherTeacherSkill response = mapper.MapModelToBO(1, model);

			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherTeacherSkillMapper();
			BOTeacherTeacherSkill bo = new BOTeacherTeacherSkill();
			bo.SetProperties(1, 1, true);
			ApiTeacherTeacherSkillResponseModel response = mapper.MapBOToModel(bo);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherTeacherSkillMapper();
			BOTeacherTeacherSkill bo = new BOTeacherTeacherSkill();
			bo.SetProperties(1, 1, true);
			List<ApiTeacherTeacherSkillResponseModel> response = mapper.MapBOToModel(new List<BOTeacherTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fab4102e4c74bad4f8ff1c6d0a6a4a50</Hash>
</Codenesium>*/