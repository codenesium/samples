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
	[Trait("Table", "TeacherXTeacherSkill")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTeacherXTeacherSkillMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTeacherXTeacherSkillMapper();
			ApiTeacherXTeacherSkillRequestModel model = new ApiTeacherXTeacherSkillRequestModel();
			model.SetProperties(1, 1);
			BOTeacherXTeacherSkill response = mapper.MapModelToBO(1, model);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherXTeacherSkillMapper();
			BOTeacherXTeacherSkill bo = new BOTeacherXTeacherSkill();
			bo.SetProperties(1, 1, 1);
			ApiTeacherXTeacherSkillResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherXTeacherSkillMapper();
			BOTeacherXTeacherSkill bo = new BOTeacherXTeacherSkill();
			bo.SetProperties(1, 1, 1);
			List<ApiTeacherXTeacherSkillResponseModel> response = mapper.MapBOToModel(new List<BOTeacherXTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>50d532794c9bef82b32c20e2a4fd678d</Hash>
</Codenesium>*/