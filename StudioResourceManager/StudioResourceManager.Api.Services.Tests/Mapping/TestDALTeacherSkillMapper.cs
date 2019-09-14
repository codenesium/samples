using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeacherSkillMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTeacherSkillMapper();
			ApiTeacherSkillServerRequestModel model = new ApiTeacherSkillServerRequestModel();
			model.SetProperties("A");
			TeacherSkill response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill item = new TeacherSkill();
			item.SetProperties(1, "A");
			ApiTeacherSkillServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTeacherSkillMapper();
			TeacherSkill item = new TeacherSkill();
			item.SetProperties(1, "A");
			List<ApiTeacherSkillServerResponseModel> response = mapper.MapEntityToModel(new List<TeacherSkill>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3bd21f43ba286337a331305e7c030371</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/