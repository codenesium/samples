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
    <Hash>3d91539e0bfcc85be776207b03caccda</Hash>
</Codenesium>*/