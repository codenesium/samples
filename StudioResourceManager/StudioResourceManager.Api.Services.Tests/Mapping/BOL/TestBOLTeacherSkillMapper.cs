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
	[Trait("Table", "TeacherSkill")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTeacherSkillMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTeacherSkillMapper();
			ApiTeacherSkillRequestModel model = new ApiTeacherSkillRequestModel();
			model.SetProperties("A", true);
			BOTeacherSkill response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A", true);
			ApiTeacherSkillResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherSkillMapper();
			BOTeacherSkill bo = new BOTeacherSkill();
			bo.SetProperties(1, "A", true);
			List<ApiTeacherSkillResponseModel> response = mapper.MapBOToModel(new List<BOTeacherSkill>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>449aa0794cb486f08dc1a3fb640a44fd</Hash>
</Codenesium>*/