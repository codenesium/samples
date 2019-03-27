using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherTeacherSkill")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeacherTeacherSkillMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			ApiTeacherTeacherSkillServerRequestModel model = new ApiTeacherTeacherSkillServerRequestModel();
			model.SetProperties(1);
			TeacherTeacherSkill response = mapper.MapModelToEntity(1, model);

			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(1, 1);
			ApiTeacherTeacherSkillServerResponseModel response = mapper.MapEntityToModel(item);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(1, 1);
			List<ApiTeacherTeacherSkillServerResponseModel> response = mapper.MapEntityToModel(new List<TeacherTeacherSkill>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1708c04fa7b3f499259adc1b08e04268</Hash>
</Codenesium>*/