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
			model.SetProperties(1, 1);
			TeacherTeacherSkill response = mapper.MapModelToEntity(1, model);

			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(1, 1, 1);
			ApiTeacherTeacherSkillServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTeacherTeacherSkillMapper();
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(1, 1, 1);
			List<ApiTeacherTeacherSkillServerResponseModel> response = mapper.MapEntityToModel(new List<TeacherTeacherSkill>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4132cf081321dcfc1acb01808d0ad75f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/