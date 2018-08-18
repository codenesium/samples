using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
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
			ApiTeacherSkillRequestModel model = new ApiTeacherSkillRequestModel();
			model.SetProperties("A", 1);
			BOTeacherSkill response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A", 1);
			ApiTeacherSkillResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A", 1);
			List<ApiTeacherSkillResponseModel> response = mapper.MapBOToModel(new List<BOTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>08a5de833f064e976185a547d4b73913</Hash>
</Codenesium>*/